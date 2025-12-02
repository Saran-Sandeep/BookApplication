using System.Security.Claims;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models.Models;
using BookApplication1.Models.ViewModels;
using BookApplication1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Razorpay.Api;

namespace BookApplication1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM shoppingCartVM { get; set; }
        private readonly RazorpaySettings _razorpaySettings;
        public ShoppingCartController(IUnitOfWork unitOfWork, IOptions<RazorpaySettings> options)
        {
            _unitOfWork = unitOfWork;
            _razorpaySettings = options.Value;
        }

        [Authorize]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<ShoppingCart> shoppingCartList = _unitOfWork.ShoppingCartRepository
                .GetAll(i => i.ApplicationUserId == userId, includeProperties: "Product")
                .ToList();

            shoppingCartVM = new()
            {
                ShoppingCartList = shoppingCartList,
                OrderHeader = new()
                {
                    OrderTotal = shoppingCartList.Sum(i => i.Product.Price * i.count)
                }
            };
            return View(shoppingCartVM);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(int id, string change)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Load existing cart record including Product (optional)
            ShoppingCart cartItem = _unitOfWork.ShoppingCartRepository
                .Get(i => i.Id == id && i.ApplicationUserId == userId);

            if (cartItem == null)
                return NotFound();

            // Apply change
            if (change == "+1")
            {
                cartItem.count += 1;
            }
            else if (change == "-1")
            {
                if (cartItem.count > 1)
                {
                    cartItem.count -= 1;
                }
                else
                {
                    // If count goes to zero, remove item entirely
                    _unitOfWork.ShoppingCartRepository.Remove(cartItem);
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
            }

            _unitOfWork.ShoppingCartRepository.Update(cartItem);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Remove(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCart cartItem = _unitOfWork.ShoppingCartRepository
                .Get(i => i.Id == id && i.ApplicationUserId == userId);

            if (cartItem == null)
                return NotFound();

            _unitOfWork.ShoppingCartRepository.Remove(cartItem);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ApplicationUser applicationUser = _unitOfWork.ApplicationUserRepository
                                    .Get(u => u.Id == userId);

            IEnumerable<ShoppingCart> shoppingCartList =
                _unitOfWork.ShoppingCartRepository
                    .GetAll(i => i.ApplicationUserId == userId,
                            includeProperties: "Product")
                    .ToList();

            if (applicationUser == null || shoppingCartList == null) return NotFound();

            shoppingCartVM = new()
            {
                ShoppingCartList = shoppingCartList,
                OrderHeader = new()
                {
                    ApplicationUserId = userId,
                    OrderTotal = shoppingCartList.Sum(i => i.Product.Price * i.count),
                    Name = applicationUser.Name,
                    PhoneNumber = applicationUser.PhoneNumber,
                    StreetAddress = applicationUser.StreetAddress,
                    City = applicationUser.City,
                    State = applicationUser.State,
                    PostalCode = applicationUser.PostalCode
                }
            };

            return View(shoppingCartVM);
        }

        [Authorize]
        [HttpPost, ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ApplicationUser applicationUser = _unitOfWork.ApplicationUserRepository
                                    .Get(u => u.Id == userId);

            IEnumerable<ShoppingCart> shoppingCartList =
                _unitOfWork.ShoppingCartRepository
                    .GetAll(i => i.ApplicationUserId == userId,
                            includeProperties: "Product")
                    .ToList();

            if (applicationUser == null || shoppingCartList == null) return NotFound();
            if (!shoppingCartList.Any())
                return RedirectToAction("Index");

            shoppingCartVM.ShoppingCartList = shoppingCartList;
            shoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            shoppingCartVM.OrderHeader.ApplicationUserId = userId;
            shoppingCartVM.OrderHeader.OrderTotal = shoppingCartList.Sum(i => i.Product.Price * i.count);

            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                //customer account, capture payment
                shoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
                shoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
            }
            else
            {
                //company account
                shoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusDelayedPayment;
                shoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;
            }

            _unitOfWork.OrderHeaderRepository.Add(shoppingCartVM.OrderHeader);
            _unitOfWork.Save();
            foreach (var cart in shoppingCartVM.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = shoppingCartVM.OrderHeader.Id,
                    Price = cart.Product.Price,
                    Count = cart.count
                };

                _unitOfWork.OrderDetailRepository.Add(orderDetail);
            }
            _unitOfWork.Save();

            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                //customer account, capture payment
                // razorpay logic
                int amountInPaise = (int)(shoppingCartVM.OrderHeader.OrderTotal * 100);

                RazorpayClient client = new(
                    _razorpaySettings.Key,
                    _razorpaySettings.Secret
                    );

                if (string.IsNullOrEmpty(_razorpaySettings.Key) || string.IsNullOrEmpty(_razorpaySettings.Secret))
                {
                    throw new Exception("Razorpay Key or Secret is not configured!");
                }


                Dictionary<string, object> options = new()
                {
                    { "amount", amountInPaise},
                    { "currency", "INR"},
                    { "receipt", shoppingCartVM.OrderHeader.Id.ToString() },
                    //{ "payment_capture", 1 }
                };


                Order razorOrder = client.Order.Create(options);

                //Store the Razorpay Order Id in database
                shoppingCartVM.OrderHeader.RazorpayOrderId = razorOrder["id"].ToString();
                _unitOfWork.Save();

                ViewBag.orderId = razorOrder["id"].ToString();

                return RedirectToAction("RazorCheckout", new { orderId = shoppingCartVM.OrderHeader.RazorpayOrderId });
            }

            _unitOfWork.ShoppingCartRepository.RemoveRange(shoppingCartVM.ShoppingCartList);
            _unitOfWork.Save();

            return RedirectToAction(nameof(OrderConfirmation), new { id = shoppingCartVM.OrderHeader.Id });
        }

        public IActionResult RazorCheckout(int orderId)
        {
            OrderHeader? order = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == orderId);
            if (order == null)
                return NotFound();

            ViewBag.OrderId = order.RazorpayOrderId;
            ViewBag.Amount = (int)(order.OrderTotal * 100); // in paise
            ViewBag.Key = _razorpaySettings.Key;
            ViewBag.OrderHeaderId = order.Id; // so we know which order to update later

            return View();
        }


        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }
    }
}
