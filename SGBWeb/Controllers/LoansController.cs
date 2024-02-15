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
    public class LoansController : Controller
    {
        LoanService LoanService = new LoanService();
        private LibraryDbContext db = new LibraryDbContext();

        // GET: Loans
        public ActionResult Index()
        {
            var loans = LoanService.GetAllLoans();
            return View(loans);
        }

        // GET: Loans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loans/Create
        public ActionResult Create()
        {
            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "Title");
            ViewBag.CopyID = new SelectList(db.Copies, "CopyID", "ISBN");
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName");
            ViewBag.UserId = new SelectList(db.Members, "MemberID", "FirstName");
            var model = new Loan();
            return View(model);
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanID,ISBN,CopyID,MemberID,UserId,LoanDate,DueDate,ReturnedDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "Title", loan.ISBN);
            ViewBag.CopyID = new SelectList(db.Copies, "CopyID", "ISBN", loan.CopyID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", loan.MemberID);
            ViewBag.UserId = new SelectList(db.Members, "MemberID", "FirstName", loan.UserId);
            return View(loan);
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "Title", loan.ISBN);
            ViewBag.CopyID = new SelectList(db.Copies, "CopyID", "ISBN", loan.CopyID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", loan.MemberID);
            ViewBag.UserId = new SelectList(db.Members, "MemberID", "FirstName", loan.UserId);
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanID,ISBN,CopyID,MemberID,UserId,LoanDate,DueDate,ReturnedDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "Title", loan.ISBN);
            ViewBag.CopyID = new SelectList(db.Copies, "CopyID", "ISBN", loan.CopyID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", loan.MemberID);
            ViewBag.UserId = new SelectList(db.Members, "MemberID", "FirstName", loan.UserId);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loans.Find(id);
            db.Loans.Remove(loan);
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
