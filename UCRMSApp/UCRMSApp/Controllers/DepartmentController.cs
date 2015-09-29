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
    public class DepartmentController : Controller
    {
        private DBContext db = new DBContext();
       
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        
        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,DepartmentCode,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                if (db.Departments.Any(d => d.DepartmentName == department.DepartmentName))
                {
                    ModelState.AddModelError("", "Department name already exists");
                }
                else if (db.Departments.Any(d => d.DepartmentCode == department.DepartmentCode))
                {
                    ModelState.AddModelError("", "Department Code already exists");
                }
                else
                {

                    db.Departments.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            return View(department);
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
