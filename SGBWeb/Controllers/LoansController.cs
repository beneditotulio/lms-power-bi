using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using SGBWeb.Data;
using SGBWeb.Models;
using SGBWeb.Services;

namespace SGBWeb.Controllers
{
    [Authorize]
    public class LoansController : Controller
    {
        LoanService LoanService = new LoanService();
        SettingService SettingService = new SettingService();
        MemberService MemberService = new MemberService();
        BookService BookService = new BookService();
        private LibraryDbContext db = new LibraryDbContext();

        //--Ativo: Indica que o empréstimo está corrente e o livro ainda não foi devolvido.
        //--Finalizado: O livro foi devolvido, e o empréstimo está completo.
        //--Atrasado: O livro não foi devolvido até a data de vencimento.
        //--Renovado: O empréstimo foi estendido além da data de vencimento original.
        //--Reservado: O livro está reservado para empréstimo, mas o processo de empréstimo ainda não foi iniciado.
        //--Cancelado: O empréstimo foi cancelado antes do livro ser devolvido ou durante o período de empréstimo.

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
            Loan loan = LoanService.GetLoanById(id.GetValueOrDefault());
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
            //ViewBag.CopyID = new SelectList(db.Copies, "CopyID", "ISBN");
            ViewBag.MemberID = new SelectList(db.Members.Where(x=>x.MemberType == "Estudante"), "MemberID", "FirstName");
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
                if (loan.ISBN == null)
                {
                    TempData["errorMessage"] = "Não foi possível gravar o registo, selecione um livro!";
                    return RedirectToAction("Index");
                }
                Copy copy = BookService.GetAvailableBookCopyByISBN(loan.ISBN);
                if (copy == null)
                {
                    TempData["errorMessage"] = "Não foi possível gravar o registo, não existem cópias disponíveis para este livro!";
                    return RedirectToAction("Index");
                }
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = claim.Value;

                Setting setting = SettingService.GetDefaultSetting();
                loan.LoanDate = DateTime.Now;
                loan.UserId = MemberService.GetMemberIdByUserId(userId);
                loan.DueDate = loan.LoanDate.AddDays(setting.DaysForReturn.GetValueOrDefault());
                loan.ReturnedDate = new DateTime(1900, 01, 01);
                loan.CopyID = copy.CopyID;
                loan.Status = "Ativo";
                LoanService.AddLoan(loan);
                return RedirectToAction("Index");
                TempData["successMessage"] = "Registo Gravado com sucesso!";
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
                LoanService.UpdateLoan(loan);

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
            Loan loan = LoanService.GetLoanById(id.GetValueOrDefault());
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
            LoanService.DeleteLoan(id);
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
