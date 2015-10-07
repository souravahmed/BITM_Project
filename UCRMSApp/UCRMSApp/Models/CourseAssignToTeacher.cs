using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace UCRMSApp.Models
{
    [Table("CourseAssignToTeacher")]
    public class CourseAssignToTeacher
    {
        [Key]
        public int CourseAssignID { set; get; }
       
        public int DepartmentID { get; set; }

        public int TeacherID { get; set; }

        [DisplayName("Credit to be taken")]
       
        public string CreditTobeTaken { set; get; }
         [DisplayName("Remaining credit")]
         
        public double RemainingCredit { set; get; }
        public int CourseID { get; set; }
        public string Name { set; get; }
        public string Credit { set; get; }


        public virtual Department Department { set; get; }
        public virtual Teacher Teacher { set; get; }

        public virtual Course Course { set; get; }
}
}