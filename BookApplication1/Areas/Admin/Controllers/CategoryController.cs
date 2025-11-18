using BookApplication1.DataAccess.Repository;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categoriesList = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(categoriesList);
        }

        public IActionResult  Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category) {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDB = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if(categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if(categoryFromDB == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(categoryFromDB);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Category");
        }

    }
}
