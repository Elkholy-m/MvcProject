using FirstWebApp.Data;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FirstWebApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ItemsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateViewBag(int selectedId = 1)
        {
            SelectList selectList = new SelectList(_dbContext.Categories.ToList(), "Id", "Name", selectedId);
            ViewBag.CategoriesList = selectList;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> _items = _dbContext.items.ToList();
            return View(_items);
        }
        [HttpGet]
        public IActionResult New()
        {
            CreateViewBag();
            return View();
        }
        [HttpPost]
        public IActionResult New(Item _item)
        {
            if (_item.Price.Equals(decimal.TryParse(_item.Name, out decimal x) ? x : decimal.MaxValue))
            {
                ModelState.AddModelError("Name", "Price Can't Be Equals Name");
            }
            if (ModelState.IsValid)
            {
                _dbContext.items.Add(_item);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = $"{_item.Name} Added Successfully";
                 return RedirectToAction("Index");
            }
            else
            {
                return View(_item);
            }
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var _item = _dbContext.items.FirstOrDefault(x => x.Id == id);
            if (_item == null)
                return NotFound();
            CreateViewBag(_item.CategoryId);
            return View(_item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item _item)
        {
            if (ModelState.IsValid)
            {
                _dbContext.items.Update(_item);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = $"{_item.Name} Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(_item);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var _item = _dbContext.items.FirstOrDefault(x => x.Id == id);
            if (_item == null)
                return NotFound();
            CreateViewBag(_item.CategoryId);
            return View(_item);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id)
        {
            var _item = _dbContext.items.Find(id);
            if (_item == null)
                return NotFound();
            _dbContext.items.Remove(_item);
            _dbContext.SaveChanges();
            TempData["SuccessMessage"] = $"{_item.Name} Deleted Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel {  RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
