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
    //[Authorize(Roles = "Administrator")]
    public class BooksController : Controller
    {
        private readonly LibraryDbContext db = new LibraryDbContext();
        private readonly BookService bookService = new BookService();

        // GET: Books
        public ActionResult Index()
        {
            try
            {
                var books = bookService.GetAllBooks();
                return View(books);
            }
            catch (Exception)
            {
                // Log the exception
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = bookService.GetBookByISBN(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            PopulateDropDownLists();
            return View(new Book());
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,Title,Subtitle,CDU,BookcaseID,PublisherID,LanguageID,Pagination,PublicationYear,CategoryID,AvailableCopies,CountryID,Illustration,SelectedAuthorIDs")] Book book)
        {
            if (ModelState.IsValid)
            {
                var selectedAuthorIDs = bookService.RemoveAuthorsIds(book.SelectedAuthorIDs);
                try
                {
                    if (bookService.CreateBook(book))
                    {
                        foreach (var authorId in selectedAuthorIDs)
                        {
                            var bookAuthors = new BooksAuthors
                            {
                                AuthorID = int.Parse(authorId),
                                ISBN = book.ISBN
                            };
                            bookService.CreateBookAuthors(bookAuthors);
                        }

                        book.AvailableCopies = Math.Max(book.AvailableCopies, 1);

                        for (int i = 1; i <= book.AvailableCopies; i++)
                        {
                            var copy = new Copy
                            {
                                CopyNumber = i,
                                ISBN = book.ISBN,
                                Condition = "Disponível"
                            };
                            bookService.CreateBookCopies(copy);
                        }
                    }
                }
                catch (Exception)
                {
                    // Log the exception
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }

            PopulateDropDownLists();
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = db.Books
                .Include(b => b.BooksAuthors)
                .FirstOrDefault(b => b.ISBN == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            PopulateDropDownLists();
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,Title,Subtitle,CDU,BookcaseID,PublisherID,LanguageID,Pagination,PublicationYear,CategoryID,AvailableCopies,CountryID,Illustration,SelectedAuthorIDs")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropDownLists();
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = bookService.GetBookByISBN(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Books/GetBookCopies/5
        public ActionResult GetBookCopies(string isbn)
        {
            var copies = bookService.GetBookCopiesByISBN(isbn);
            return View(copies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateDropDownLists()
        {
            ViewBag.BookcaseID = new SelectList(db.Bookcases, "BookcaseID", "BookcaseName");
            ViewBag.CategoryID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "CATEGORIA"), "ID", "Description");
            ViewBag.CountryID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "COUNTRY"), "ID", "Description");
            ViewBag.LanguageID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "IDIOMA"), "ID", "Description");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
        }
    }
}
