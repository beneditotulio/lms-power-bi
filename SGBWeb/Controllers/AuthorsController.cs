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
using Syncfusion.XlsIO;

namespace SGBWeb.Controllers
{
    public class AuthorsController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();
        AuthorService AuthorServices = new AuthorService();
        GeneralDataService GeneralDataService = new GeneralDataService();
        // GET: Authors
        public ActionResult Index()
        {
            var model = AuthorServices.GetAllAuthors();
            return View(model);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            ViewData["GeneralData"] = GeneralDataService.GetAllGeneralDataByType("COUNTRY");
            var model = new Author();
            return View(model);
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuthorName,DateOfBirth,CountryOfOrigin,Biography,Website,Email,Phone")] Author author)
        {
            if (ModelState.IsValid)
            {
                //Verifica a existencia da editora, caso nao exista, cria
                if (!AuthorServices.ExistsAuthorName(author.AuthorName))
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                }
                else
                {
                    TempData["errorMessage"] = $"Ja existe um autor com o nome: { author.AuthorName}" ;
                }

                return RedirectToAction("Index");
            }

            ViewData["GeneralData"] = GeneralDataService.GetAllGeneralDataByType("COUNTRY");
            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            ViewData["GeneralData"] = GeneralDataService.GetAllGeneralDataByType("COUNTRY");
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuthorName,DateOfBirth,CountryOfOrigin,Biography,Website,Email,Phone")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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

        public ActionResult ImportAuthors()
        {
            return PartialView("~/Views/Authors/_Import.cshtml");
        }
        public ActionResult Upload(FormCollection formCollection)
        {
            //Create an instance of ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if (String.IsNullOrEmpty(file.FileName))
                {
                    TempData["errorMessage"] = "Por favor, selecione o ficheiro que pretende importar.";
                    return RedirectToAction(nameof(Index));
                }
                string path = Server.MapPath("~/Content/FileUploads/" + file.FileName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                file.SaveAs(path);

                //Instantiate the Excel application object
                IApplication application = excelEngine.Excel;

                //Set the default application version
                application.DefaultVersion = ExcelVersion.Excel2016;

                //Load the existing Excel workbook into IWorkbook
                IWorkbook workbook = application.Workbooks.Open(path);

                //Get the first worksheet in the workbook into IWorksheet
                IWorksheet worksheet = workbook.Worksheets[0];

                string res = AuthorService.ImportAuthor(workbook, worksheet);
                //string res = "";
                if (res.Contains("sucesso"))
                    TempData["successMessage"] = res;
                else
                    TempData["errorMessage"] = res;
                // delete uploaded file
                System.IO.File.Delete(path);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult SearchAuthors(string searchTerm)
         {
            // Perform the author search and return a partial view with search results
            var authors = AuthorServices.GetAuthorByName(searchTerm);
            return PartialView(authors);
        }

    }
}
