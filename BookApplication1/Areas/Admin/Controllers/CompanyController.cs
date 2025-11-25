using BookApplication1.DataAccess.Repository;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models.Models;
using BookApplication1.Models.ViewModels;
using BookApplication1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Company> companiesList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return View(companiesList);
        }

        [HttpGet("Admin/Company/Upsert")]
        [HttpGet("Admin/Company/Upsert/{companyId}")]
        public IActionResult Upsert(int? companyId)
        {
            Company company;
            if (companyId == null || companyId == 0)
            {
                // Create /Insert
                company = new();
            }
            else
            {
                // Edit /Update
                company = _unitOfWork.CompanyRepository.Get(c => c.Id == companyId);
                if (company == null) { return NotFound(); }
            }

            return View(company);
        }


        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid && company != null)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.CompanyRepository.Add(company);
                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(company);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(company);
            }
        }


        [HttpPost("Admin/Company/Delete/{companyId}")]
        public IActionResult Delete(int? companyId)
        {
            if (companyId == null || companyId == 0)
            {
                return NotFound();
            }
            Company companyDetails = _unitOfWork.CompanyRepository.Get(c => c.Id == companyId);
            if (companyDetails == null)
            {
                return NotFound();
            }
            _unitOfWork.CompanyRepository.Remove(companyDetails);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Company");
        }

    }
}
