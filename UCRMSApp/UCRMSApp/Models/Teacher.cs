using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCRMSApp.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        public int TeacherID { get; set; }
         [Required]
         [DisplayName("Name")]
        public string TeacherName { get; set; }
         [Required]         
        public string Address{ get; set; }
         [Required(ErrorMessage = "Please enter your email address")]
         [DataType(DataType.EmailAddress)]
        [Remote("IsEmailExists", "Teacher", ErrorMessage = "Email Must Be Unique.")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$", ErrorMessage = "Enter valid number")]
        public string ContacNumber { get; set; }
        [Required(ErrorMessage = "Select a Designation")]
        [DisplayName("Designation")]
        public int DesignationID { get; set; }
        [Required(ErrorMessage = "Select a department")]
        [DisplayName("Department")]
        public int DepartmentID { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = " Credit to be taken can't be less than 1")]
        [DisplayName("Credit To Be Taken")]
        public double CreditToBeTaken { get; set; }


        public virtual Designation Designation { set; get; }
        public virtual Department Department { set; get; }

        public virtual ICollection<CourseAssignToTeacher> CourseAssignToTeachers { set; get; } 
       
    }
}