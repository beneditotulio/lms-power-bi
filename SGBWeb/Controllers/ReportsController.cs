using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGBWeb.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student Report
        public ActionResult Report()
        {
            return View();
        }
        // GET: Student Report
        public ActionResult RegionalSales()
        {
            return View();
        }
        public ActionResult Analytics()
        {
            return View();
        }
    }
}