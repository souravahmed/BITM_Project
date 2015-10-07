using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace UCRMSApp.Models
{
    [Table("Course")]
    public class Course
    {
     
        public int CourseID { set; get; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Code must be at least five (5) characters long")]
        [DisplayName("Code")]
        [Remote("IsCodeExists", "Course", ErrorMessage = "Course Code Must Be Unique.")]
        public string CourseCode { set; get; }
        [Required]
        [DisplayName("Name")]
        [Remote("IsNameExists", "Course", ErrorMessage = "Course Name Must Be Unique.")]
        public string CourseName { set; get; }
        [Required]
        [Range(0.5, 5.0, ErrorMessage = "credit cannot be less than 0.5 and more than 5.0")]
        public double Credit { set; get; } // if data type float is used than there will be an exception
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { set; get; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Select a department")]
        public int DepartmentID { set; get; }
       
        [DisplayName("Semester")]
        [Required(ErrorMessage = "Select a semester")]
        public int SemesterID { set; get; }

      
        public virtual Department Department { set; get; }
   
        public virtual Semester Semester { set; get; }

        public virtual ICollection<CourseAssignToTeacher> CourseAssignToTeachers { set; get; } 

      
     

    }
}