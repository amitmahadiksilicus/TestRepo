using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace MyCompany.Models
{
    public class MyCompanyContext:DbContext
    {
        public MyCompanyContext(): base("db_MyCollege")
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }

    public class Employee
    {
        public Employee() { }
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string ContactNumber { get; set; }
       
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

       
    }

    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
       
        public virtual ICollection<Employee> Employees { get; set; }
    }
}