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
            var cat1 = _repository.SelectOne(x => x.Name == "Computer");
            var cat2 = await _repository.SelectOneAsync(x => x.Id == 4);
            return View(await _repository.FindAllAsync());
        }
    }
}
