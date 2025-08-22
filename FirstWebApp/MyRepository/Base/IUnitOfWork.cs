using FirstWebApp.Areas.Employees.Models;
using FirstWebApp.Models;

namespace FirstWebApp.MyRepository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Category> Categories { get; }
        IRepository<Item> Items { get; }
        int Commit();

    }
}
