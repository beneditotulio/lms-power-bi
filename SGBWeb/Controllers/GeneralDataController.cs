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
    public class GeneralDataController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();
        GeneralDataService GeneralDataService = new GeneralDataService();
        // GET: GeneralData
        public ActionResult Index()
        {
            var model = GeneralDataService.GetAllGeneralData();
            return View(model);
        }

        // GET: GeneralData/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralData generalData = db.GeneralDatas.Find(id);
            if (generalData == null)
            {
                return HttpNotFound();
            }
            return View(generalData);
        }

        // GET: GeneralData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ParentId,ClassifierType,Description,ShortName,IsDefault,ExtCode")] GeneralData generalData)
        {
            if (ModelState.IsValid)
            {
                db.GeneralDatas.Add(generalData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(generalData);
        }

        // GET: GeneralData/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralData generalData = db.GeneralDatas.Find(id);
            if (generalData == null)
            {
                return HttpNotFound();
            }
            return View(generalData);
        }

        // POST: GeneralData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ParentId,ClassifierType,Description,ShortName,IsDefault,ExtCode")] GeneralData generalData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generalData);
        }

        // GET: GeneralData/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralData generalData = db.GeneralDatas.Find(id);
            if (generalData == null)
            {
                return HttpNotFound();
            }
            return View(generalData);
        }

        // POST: GeneralData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GeneralData generalData = db.GeneralDatas.Find(id);
            db.GeneralDatas.Remove(generalData);
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
