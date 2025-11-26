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
    }
}
