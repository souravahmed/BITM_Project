using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace UCRMSApp.Models
{
    [Table("Department")]
    public class Department
    {
    
        public int DepartmentID { set; get; }

        [Required(ErrorMessage = "Code is required")]

        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be between 2 to 7 characters")]

        [DisplayName("Code")]
        [Remote("IsCodeExists", "Department", ErrorMessage = "Department Code Must Be Unique.")]
        public  string DepartmentCode { set; get; }

        [Required(ErrorMessage = "Name is required")]

        [DisplayName("Name")]
        [Remote("IsNameExists", "Department", ErrorMessage = "Department Name Must Be Unique.")]
        public  string DepartmentName { set; get; }

        public virtual ICollection<Course> Courses { set; get; }
        public virtual ICollection<Teacher> Teachers { set; get; }

        public virtual ICollection<CourseAssignToTeacher> CourseAssignToTeachers { set; get; } 
   
    }
}