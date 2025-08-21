using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.Areas.Employees.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string? EmployeeName { get; set; }
        [Required]
        [DisplayName("Email")]
        public string? EmployeeEmail { get; set; }
        [DisplayName("Phone")]
        public string? EmployeePhone{ get; set; }
        [Range(20, 60, ErrorMessage = "Age = {0} is not between {1} and {2}")]
        public int? EmployeeAge{ get; set; }
        [Range(6000, 100000, ErrorMessage = "Salary = {0} is not between {1} and {2}")]
        public decimal? EmployeeSalary{ get; set; }
    }
}
