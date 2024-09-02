using SGBWeb.Models;
using SGBWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGBWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        HomeService _homeService = new HomeService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            var viewModel = new HomeViewModel
            {
                TotalLoans = _homeService.GetTotalLoans(),
                LoanIncreasePercentage = _homeService.GetLoanIncreasePercentage(),
                TotalFines = _homeService.GetTotalFines(),
                FineIncreasePercentage = _homeService.GetFineIncreasePercentage(),
                TotalMembers = _homeService.GetTotalMembers(),
                MemberIncreasePercentage = _homeService.GetMemberIncreasePercentage(),
                RecentFines = _homeService.GetRecentFines(),
                RecentLoanActivities = _homeService.GetRecentLoanActivities()
            };
            return View(viewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Faq()
        {
            ViewBag.Message = "Your F.A.Q. page.";

            return View();
        }
    }
}