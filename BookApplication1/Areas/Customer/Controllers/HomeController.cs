using System.Diagnostics;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models;
using BookApplication1.Models.Models;
using BookApplication1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            Product productDetails = _unitOfWork.ProductRepository.Get(p => p.Id == productId, includeProperties: "Category");

            return productDetails == null ? NotFound() : View(productDetails);
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
