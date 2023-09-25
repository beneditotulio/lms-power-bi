using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGBWeb.Data;
using SGBWeb.Models;
using SGBWeb.Services;

namespace SGBWeb.Controllers
{
    public class BookcaseController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();
        BookcaseService BookcaseServices = new BookcaseService();
        // GET: Bookcase
        public ActionResult Index()
        {
            var model = BookcaseServices.GetAllBookcases();
            return View(db.Bookcases.ToList());
        }

        // GET: Bookcase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookcase bookcase = db.Bookcases.Find(id);
            if (bookcase == null)
            {
                return HttpNotFound();
            }
            return View(bookcase);
        }

        // GET: Bookcase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookcase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookcaseID,BookcaseName,Location,Capacity,Description")] Bookcase bookcase)
        {
            if (ModelState.IsValid)
            {
                db.Bookcases.Add(bookcase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookcase);
        }

        // GET: Bookcase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookcase bookcase = db.Bookcases.Find(id);
            if (bookcase == null)
            {
                return HttpNotFound();
            }
            return View(bookcase);
        }

        // POST: Bookcase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookcaseID,BookcaseName,Location,Capacity,Description")] Bookcase bookcase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookcase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookcase);
        }

        // GET: Bookcase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookcase bookcase = db.Bookcases.Find(id);
            if (bookcase == null)
            {
                return HttpNotFound();
            }
            return View(bookcase);
        }

        // POST: Bookcase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookcase bookcase = db.Bookcases.Find(id);
            db.Bookcases.Remove(bookcase);
            db.SaveChanges();
            return RedirectToAction("Index");
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
