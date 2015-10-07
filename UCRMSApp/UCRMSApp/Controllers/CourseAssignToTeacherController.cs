using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UCRMSApp.Models;

namespace UCRMSApp.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        private DBContext db = new DBContext();

        // GET: /CourseAssignToTeacher/
       
        // GET: /CourseAssignToTeacher/Details/5
       
        // GET: /CourseAssignToTeacher/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: /CourseAssignToTeacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseAssignID,DepartmentID,TeacherID,CreditTobeTaken,RemainingCredit,CourseID,Name,Credit")] CourseAssignToTeacher courseassigntoteacher)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssignToTeachers.Add(courseassigntoteacher);
                db.SaveChanges();

                ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", courseassigntoteacher.CourseID);
                ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", courseassigntoteacher.DepartmentID);
                ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", courseassigntoteacher.TeacherID);
                return View();

            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", courseassigntoteacher.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", courseassigntoteacher.DepartmentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", courseassigntoteacher.TeacherID);
            return View(courseassigntoteacher);
        }

        // GET: /CourseAssignToTeacher/Edit/5
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
