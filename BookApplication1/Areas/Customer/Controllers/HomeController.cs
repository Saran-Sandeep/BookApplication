using System.Diagnostics;
using System.Security.Claims;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models;
using BookApplication1.Models.Models;
using BookApplication1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace BookApplication1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category").ToList();
            return View(productList);
        }

        [HttpGet("Customer/Home/Details/{productId}")]
        public IActionResult Details(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return NotFound();
            }

            ShoppingCart shoppingCart = new();

            Product productDetails = _unitOfWork.ProductRepository.Get(p => p.Id == productId, includeProperties: "Category");
            if (productDetails == null)
                return NotFound();
            shoppingCart.Product = productDetails;
            return View(shoppingCart);
        }

        [HttpPost("Customer/Home/Details/{productId}")]
        [Authorize]
        public IActionResult Details(int? quantity,int? productId)
        {
            if (productId == null || quantity == null || quantity == 0)
                return BadRequest();

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCart shoppingCartFromDB = _unitOfWork.ShoppingCartRepository.
                                                Get(i => i.ProductId == productId && i.ApplicationUserId == userId);

            if(shoppingCartFromDB != null)
            {
                shoppingCartFromDB.count += (int)quantity;
            }
            else
            {
                ShoppingCart shoppingCart = new()
                {
                    ApplicationUserId = userId,
                    ProductId = (int)productId,
                    count = (int)quantity
                };
                _unitOfWork.ShoppingCartRepository.Add(shoppingCart);
            }

            _unitOfWork.Save();
            return RedirectToAction("Details");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
