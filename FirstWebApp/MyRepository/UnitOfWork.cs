using FirstWebApp.Areas.Employees.Models;
using FirstWebApp.Data;
using FirstWebApp.Models;
using FirstWebApp.MyRepository.Base;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstWebApp.MyRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Employees = new Repository<Employee>(context);
            Categories = new Repository<Category>(context);
            Items = new Repository<Item>(context);
        }
        public IRepository<Employee> Employees { get; set; }

        public IRepository<Category> Categories { get; set; }

        public IRepository<Item> Items { get; set; }

        public int Commit() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
