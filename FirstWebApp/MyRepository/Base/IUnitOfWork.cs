using FirstWebApp.Areas.Employees.Models;
using FirstWebApp.Models;

namespace FirstWebApp.MyRepository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IRepository<Category> Categories { get; }
        IRepository<Item> Items { get; }
        int Commit();
        public Task<int> CommitAsync();

    }
}
