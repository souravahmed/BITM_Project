using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UCRMSApp.Models
{
    [Table("Department")]
    public class Department
    {
        public int DepartmentID { set; get; }

        [Required(ErrorMessage = "Code is required")]

        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be between 2 to 7 characters")]

        public  string DepartmentCode { set; get; }

        [Required(ErrorMessage = "Name is required")]

        public  string DepartmentName { set; get; }
    }
}