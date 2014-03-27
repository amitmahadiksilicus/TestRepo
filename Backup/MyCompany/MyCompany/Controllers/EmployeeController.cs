using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCompany.Models;

namespace MyCompany.Controllers
{
    public class EmployeeController : Controller
    {
        private MyCompanyContext db = new MyCompanyContext();

        //
        // GET: /Employee/

        public ActionResult Index(string sortOrder, string searchString,int page=1)
        {
            const int pageSize=5;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.ContNoSortParm = sortOrder == "ContNo" ? "ContNo_desc" : "ContNo";
            ViewBag.DeptSortParm = sortOrder == "Dept" ? "Dept_desc" : "Dept";

            var employee = db.Employees.Include(e => e.Department);


            if (!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(s => s.EmployeeName.ToUpper().Contains(searchString.ToUpper()));
                                  
            }
            employee = employee.OrderBy(s => s.EmployeeName)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize);
            switch (sortOrder)
            {
                case "Name_desc":
                    employee = employee.OrderByDescending(s => s.EmployeeName);
                    break;
                case "ContNo":
                    employee = employee.OrderBy(s => s.ContactNumber);
                    break;
                case "ContNo_desc":
                    employee = employee.OrderByDescending(s => s.ContactNumber);
                    break;
                case "Dept":
                    employee = employee.OrderBy(s => s.Department.DepartmentName);
                    break;
                case "Dept_desc":
                    employee = employee.OrderByDescending(s => s.Department.DepartmentName);
                    break;
                default:
                    employee = employee.OrderBy(s => s.EmployeeName);
                    break;
            }

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = Math.Ceiling((double)db.Employees.Count() / pageSize);

            return View(employee.ToList());
        
            //var employees = db.Employees.Include(e => e.Department);
            //return View(employees.ToList());
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentID);
            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentID);
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentID);
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}