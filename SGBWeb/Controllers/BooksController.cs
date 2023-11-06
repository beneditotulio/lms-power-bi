﻿using System;
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
    public class BooksController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();
        BookService BookService = new BookService();
        // GET: Books
        public ActionResult Index()
        {
            var books = new List<Book>();
            try
            {
              books =  BookService.GetAllBooks();
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.BookcaseID = new SelectList(db.Bookcases, "BookcaseID", "BookcaseName");
            ViewBag.CategoryID = new SelectList(db.GeneralDatas.Where(x=>x.ClassifierType == "CATEGORIA").ToList(), "ID", "Description");
            ViewBag.CountryID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "COUNTRY").ToList(), "ID", "Description");
            ViewBag.LanguageID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "IDIOMA").ToList(), "ID", "Description");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,Title,Subtitle,CDU,BookcaseID,PublisherID,LanguageID,Pagination,PublicationYear,CategoryID,AvailableCopies,CountryID,Illustration,SelectedAuthorIDs")] Book book)
        {
            if (ModelState.IsValid)
            {
                var selectedAuthorIDs = BookService.RemoveAuthorsIds(book.SelectedAuthorIDs);
                try
                {
                    if (BookService.CreateBook(book))
                    {
                        for (int i = 0; i < selectedAuthorIDs.Length; i++)
                        {
                            var bookAuthors = new BooksAuthors
                            {
                                AuthorID = int.Parse(selectedAuthorIDs[i]),
                                ISBN = book.ISBN
                            };
                            BookService.CreateBookAuthors(bookAuthors);
                        }
                    }
                    
                }
                catch (Exception ex)
                {

                    throw;
                }
                return RedirectToAction("Index");
            }

            ViewBag.BookcaseID = new SelectList(db.Bookcases, "BookcaseID", "BookcaseName");
            ViewBag.CategoryID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "CATEGORIA").ToList(), "ID", "Description");
            ViewBag.CountryID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "COUNTRY").ToList(), "ID", "Description");
            ViewBag.LanguageID = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "IDIOMA").ToList(), "ID", "Description");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookcaseID = new SelectList(db.Bookcases, "BookcaseID", "BookcaseName", book.BookcaseID);
            ViewBag.CategoryID = new SelectList(db.GeneralDatas, "ID", "ParentId", book.CategoryID);
            ViewBag.CountryID = new SelectList(db.GeneralDatas, "ID", "ParentId", book.CountryID);
            ViewBag.LanguageID = new SelectList(db.GeneralDatas, "ID", "ParentId", book.LanguageID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,Title,Subtitle,CDU,BookcaseID,PublisherID,LanguageID,Pagination,PublicationYear,CategoryID,AvailableCopies,CountryID,Illustration")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookcaseID = new SelectList(db.Bookcases, "BookcaseID", "BookcaseName", book.BookcaseID);
            ViewBag.CategoryID = new SelectList(db.GeneralDatas, "ID", "ParentId", book.CategoryID);
            ViewBag.CountryID = new SelectList(db.GeneralDatas, "ID", "ParentId", book.CountryID);
            ViewBag.LanguageID = new SelectList(db.GeneralDatas, "ID", "ParentId", book.LanguageID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
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
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
