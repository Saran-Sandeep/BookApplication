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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpGet("Admin/Product/Upsert")]
        [HttpGet("Admin/Product/Upsert/{productId}")]
        public IActionResult Upsert(int? productId)
        {
            ProductVM productVM = new();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u =>
             new SelectListItem
             {
                 Text = u.Name,
                 Value = u.Id.ToString()
             });
            productVM.CategoryList = CategoryList;
            if (productId == null || productId == 0) {
                // Create /Insert
                productVM.Product = new();
            }
            else
            {
                // Edit /Update
                Product productDetails = _unitOfWork.ProductRepository.Get(p => p.Id == productId);
                if (productDetails == null) { return NotFound(); }
                productVM.Product = productDetails;
            }

             return View(productVM);

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (formFile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if(!string.IsNullOrEmpty(productVM.Product.ImageURL))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageURL);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);
                    }

                    productVM.Product.ImageURL = @"images\product\" + fileName;
                }

                if(productVM.Product.Id == 0)
                {
                    productVM.Product.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
                    productVM.Product.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);

                    _unitOfWork.ProductRepository.Add(productVM.Product);
                }
                else
                {
                    productVM.Product.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
                    _unitOfWork.ProductRepository.Update(productVM.Product);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u =>
                new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(productVM);
            }
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
    }
}
