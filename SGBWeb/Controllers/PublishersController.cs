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
using static System.Net.Mime.MediaTypeNames;

namespace SGBWeb.Controllers
{
    public class PublishersController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();
        PublisherService PublisherService = new PublisherService();

        // GET: Publishers
        public ActionResult Index()
        {
            var model = PublisherService.GetAllPublishers();
            return View(model);
        }

        // GET: Publishers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublisherID,PublisherName,Address,Phone")] Publisher publisher)
        {
            if (!String.IsNullOrEmpty(publisher.PublisherName))
            {
                PublisherService.CreatePublisher(publisher);
                TempData["successMessage"] = "Registo Gravado com sucesso!";
            }
            else
            {
                TempData["errorMessage"] = "Não foi possível gravar o registo!";
                return View(publisher);

            }
            return RedirectToAction("Index");
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = PublisherService.GetPublisherById(id.GetValueOrDefault());
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublisherID,PublisherName,Address,Phone")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                PublisherService.UpdatePublisher(publisher);
                TempData["successMessage"] = "Registo Gravado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (PublisherService.DeletePublisher(id))
            {
                TempData["successMessage"] = "Registo Gravado com sucesso!";
            }
            TempData["erroMessage"] = "Registo Gravado com sucesso!";
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

        public ActionResult ImportPublisher()
        {
            return PartialView("~/Views/Publishers/_Import.cshtml");
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

                string res = PublisherService.ImportPublisher(workbook, worksheet);
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
    }
}
