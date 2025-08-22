using FirstWebApp.Models;
using FirstWebApp.MyRepository.Base;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class CategoriesController :Controller
    {
        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}
        private readonly IRepository<Category> _repository;

        public CategoriesController(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            // Test Eager Loading
            var cat = _repository.FindAll("Items");
            var cat2 = await _repository.FindAllAsync("Items");
            return View(await _repository.FindAllAsync());
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
                _repository.AddOne(category);
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
            var category = _repository.FindById(id.Value);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateOne(category);
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
            var category = _repository.FindById(id.Value);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            if (category == null)
                return NotFound();
            _repository.DeleteOne(category);
            TempData["SuccessMessage"] = $"{category.Name} Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
