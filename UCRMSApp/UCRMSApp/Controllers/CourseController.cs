using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UCRMSApp.Models;

namespace UCRMSApp.Controllers
{
    public class CourseController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseCode,CourseName,Credit,Description,DepartmentID,SemesterID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Successfully saved";
                ModelState.Clear();
                ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", course.DepartmentID);
                ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName", course.SemesterID);
                return View();
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", course.DepartmentID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterName", course.SemesterID);
            return View(course);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public JsonResult IsCodeExists(string courseCode)
        {
            return Json(!db.Courses.Any(x=> x.CourseCode == courseCode), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsNameExists(string courseName)
        {
            return Json(!db.Courses.Any(x => x.CourseName == courseName), JsonRequestBehavior.AllowGet);
        }
    }
}
