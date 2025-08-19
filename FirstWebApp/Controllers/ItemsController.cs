using FirstWebApp.Data;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            IEnumerable<Item> _items = _dbContext.items.ToList();
            return View(_items);
        }
        [HttpGet]
        public IActionResult New()
        {
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
                 return RedirectToAction("Index");
            }
            else
            {
                return View(_item);
            }
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel {  RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
