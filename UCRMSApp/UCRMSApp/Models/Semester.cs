using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UCRMSApp.Models
{
    [Table("Semester")]
    public class Semester
    {
        
        public int SemesterID { set; get; }
        public string SemesterName { set; get; }
        public virtual ICollection<Course> Courses { set; get; } 
    }
}