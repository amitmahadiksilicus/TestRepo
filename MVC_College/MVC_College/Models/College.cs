using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace MVC_College.Models
{

    public class CollegeContext : DbContext
    {
        public CollegeContext(): base()
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }

    public class Student
    {
        public Student() { }

        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }

        public int StdandardId { get; set; }

        public virtual Standard Standard { get; set; }

        public string ContactNumber { get; set; }
    }

    public class Standard
    {
        public Standard()
        {
            Students = new List<Student>();
        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
        
}