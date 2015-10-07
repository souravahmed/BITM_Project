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
    public class TeacherController : Controller
    {
        private DBContext db = new DBContext();


       

        // GET: Teacher/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignatioName");
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherID,TeacherName,Address,Email,ContacNumber,DesignationID,DepartmentID,CreditToBeTaken")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Successfully saved";
                ModelState.Clear();
                ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", teacher.DepartmentID);
                ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignatioName", teacher.DesignationID);

                return View();
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", teacher.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignatioName", teacher.DesignationID);
            return View(teacher);
        }

       

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public JsonResult IsEmailExists(string email)
        {
            return Json(!db.Teachers.Any(x => x.Email == email), JsonRequestBehavior.AllowGet);
        }



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
