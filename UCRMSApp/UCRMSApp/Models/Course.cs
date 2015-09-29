using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMSApp.Models
{
    public class Course
    {
        public int CourseID { private set; get; }
        public string CourseCode { set; get; }
        public string CourseName { set; get; }
        public float Credit { set; get; }
        public string Description { set; get; }
        public int DepartmentID { private set; get; }
        public string Semester { set; get; }
    }
}