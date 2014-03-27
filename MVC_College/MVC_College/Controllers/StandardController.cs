using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_College.Models;

namespace MVC_College.Controllers
{
    public class StandardController : Controller
    {
        private CollegeContext db = new CollegeContext();

        //
        // GET: /Standard/

        public ActionResult Index()
        {
            return View(db.Standards.ToList());
        }

        //
        // GET: /Standard/Details/5

        public ActionResult Details(int id = 0)
        {
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        //
        // GET: /Standard/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Standard/Create

        [HttpPost]
        public ActionResult Create(Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Standards.Add(standard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standard);
        }

        //
        // GET: /Standard/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        //
        // POST: /Standard/Edit/5

        [HttpPost]
        public ActionResult Edit(Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standard);
        }

        //
        // GET: /Standard/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        //
        // POST: /Standard/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Standard standard = db.Standards.Find(id);
            db.Standards.Remove(standard);
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