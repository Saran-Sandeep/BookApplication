using System.Security.Claims;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models.Models;
using BookApplication1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<ShoppingCart> shoppingCartList = _unitOfWork.ShoppingCartRepository
                .GetAll(i => i.ApplicationUserId == userId, includeProperties: "Product")
                .ToList();
            ShoppingCartVM shoppingCartVM = new()
            {
                ShoppingCartList = shoppingCartList,
                OrderTotal = shoppingCartList.Sum(i => i.Product.Price * i.count)
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

            var cartItem = _unitOfWork.ShoppingCartRepository
                .Get(i => i.Id == id && i.ApplicationUserId == userId);

            if (cartItem == null)
                return NotFound();

            _unitOfWork.ShoppingCartRepository.Remove(cartItem);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
