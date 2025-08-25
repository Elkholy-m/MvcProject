using FirstWebApp.Models;
using FirstWebApp.MyRepository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    [Authorize(Roles = clsRoles.adminRole)]
    public class CategoriesController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}
        //private readonly IRepository<Category> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            // Test Eager Loading
            var cat = _unitOfWork.Categories.FindAll("Items");
            var cat2 = await _unitOfWork.Categories.FindAllAsync("Items");
            return View(await _unitOfWork.Categories.FindAllAsync());
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ClientFile != null)
                {
                    using (var mStrm = new MemoryStream())
                    {
                        category.ClientFile.CopyTo(mStrm);
                        category.ImgaeDB = mStrm.ToArray();
                    }
                }
                _unitOfWork.Categories.AddOne(category);
                _unitOfWork.Commit();
                TempData["SuccessMessage"] = $"{category.Name} Added Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            var category = _unitOfWork.Categories.FindById(id.Value);
            if (category == null)
                return NotFound();
            ViewBag.ImgDB = category.ImgaeDB;
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ClientFile != null)
                {
                    using (var mStrm = new MemoryStream())
                    {
                        category.ClientFile.CopyTo(mStrm);
                        category.ImgaeDB = mStrm.ToArray();
                    }
                }
                else
                {
                    //category.ImgaeDB = _unitOfWork.Categories.FindById(category.Id).ImgaeDB;
                }
                    _unitOfWork.Categories.UpdateOne(category);
                _unitOfWork.Commit();
                TempData["SuccessMessage"] = $"{category.Name} Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            var category = _unitOfWork.Categories.FindById(id.Value);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult Delete(Category category)
        {
            if (category == null)
                return NotFound();
            _unitOfWork.Categories.DeleteOne(category);
            _unitOfWork.Commit();
            TempData["SuccessMessage"] = $"{category.Name} Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
