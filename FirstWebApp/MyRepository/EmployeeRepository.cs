using FirstWebApp.Areas.Employees.Models;
using FirstWebApp.Data;
using FirstWebApp.MyRepository.Base;
using System.Linq.Expressions;

namespace FirstWebApp.MyRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public decimal GetSalary(Employee employee) => employee.EmployeeSalary.Value;

        public void SetPaySlip(Employee employee) => throw new NotImplementedException();
    }
}
