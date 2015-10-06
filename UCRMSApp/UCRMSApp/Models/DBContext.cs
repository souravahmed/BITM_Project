using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UCRMSApp.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base() { }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Semester> Semesters { set; get; } 
    }
}