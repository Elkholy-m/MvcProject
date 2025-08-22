using FirstWebApp.Models;
using FirstWebApp.MyRepository.Base;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class CategoriesController :Controller
    {
        private readonly IRepository<Category> _repository;

        public CategoriesController(IRepository<Category> repository)
        {
            _repository = repository;
        }
        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}

        public async Task<IActionResult> Index()
        {
            return View(await _repository.FindAllAsync());
        }
    }
}
