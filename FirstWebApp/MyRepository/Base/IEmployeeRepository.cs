using FirstWebApp.Areas.Employees.Models;
using System.Linq.Expressions;

namespace FirstWebApp.MyRepository.Base
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void SetPaySlip(Employee employee);
        decimal GetSalary(Employee employee);
    }
}
