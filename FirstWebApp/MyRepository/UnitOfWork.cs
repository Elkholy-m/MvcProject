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
            Employees = new EmployeeRepository(context);
            Categories = new Repository<Category>(context);
            Items = new Repository<Item>(context);
        }

        public IRepository<Category> Categories { get; private set; }
        public IRepository<Item> Items { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public int Commit() => _context.SaveChanges();
        public Task<int> CommitAsync() => _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
