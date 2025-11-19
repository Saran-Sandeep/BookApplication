using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models.Models;
using BookApplication1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace BookApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> productsList = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(productsList);
        }

        [HttpGet("Admin/Product/Details/{productId}")]
        public IActionResult Details(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return NotFound();
            }
            Product productDetails = _unitOfWork.ProductRepository.Get(p => p.Id == productId);
            if (productDetails == null)
            {
                return NotFound();
            }
            return View(productDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
                product.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);

                _unitOfWork.ProductRepository.Add(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost("Admin/Product/Delete/{productId}")]
        public IActionResult Delete(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return NotFound();
            }
            Product productDetails = _unitOfWork.ProductRepository.Get(p => p.Id == productId);
            if (productDetails == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Remove(productDetails);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Product");
        }

        [HttpGet("Admin/Product/Edit/{productId}")]
        public IActionResult Edit(int? productId)
        {
            if(productId == null || productId == 0) { return NotFound(); }
            Product productDetails = _unitOfWork.ProductRepository.Get(p => p.Id==productId);
            if (productDetails == null) { return NotFound(); }
            return View(productDetails);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
    }
}
