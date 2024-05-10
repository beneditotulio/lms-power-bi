using Microsoft.AspNet.Identity;
using SGBWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGBWeb.Controllers
{
    public class UsersController : Controller
    {
        UsersService UsersService = new UsersService();
        GeneralDataService GeneralDataService = new GeneralDataService();
        MemberService MemberService = new MemberService();

        // GET: Users
        public ActionResult Index()
        { 
            var model = UsersService.GetAllUsers();
            return View(model);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #region ADD USER PROFILE AND ROLES
        public ActionResult ProfileIndex()
        {
            var data = GeneralDataService.GetAllGeneralDataByType("USERPROFILE");
            return View("~/Views/Users/UserProfile/ProfileIndex.cshtml", data);
        }
        #endregion

        #region User Profile
        public ActionResult UsersProfile()
        {
            var model = MemberService.GetMemberIByUserName(User.Identity.GetUserName());
            return View(model);
        }
        #endregion

    }
}
