using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using SGBWeb.Data;
using SGBWeb.Models;

namespace SGBWeb.Controllers
{
    public class MembersController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public MembersController()
        {
        }
        public MembersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private LibraryDbContext db = new LibraryDbContext();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            List<AspNetRole> roles = db.Roles.ToList();
            var memberType = new List<SelectListItem>();
            foreach (var item in roles)
            {
                memberType.Add(new SelectListItem { Value = item.Name, Text = item.Name });
            }
            ViewBag.MemberType = memberType;

            //ViewBag.MemberType = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Nationality = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "COUNTRY").ToList(), "ID", "Description");
            // Creating a list of genders in Portuguese
            var genders = new List<SelectListItem>
            {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Feminino", Text = "Feminino" },
                // Add more options here as needed
            };

            // Passing the gender list to the view through ViewBag
            ViewBag.Gender = new SelectList(genders, "Value", "Text");
            var model = new Member();
            return View(model);
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MemberID,FirstName,OtherName,LastName,Gender,Nationality,Nuit,MemberType,Address,Email,Phone,DateCreate,StudentNumber,Bi,Status")] Member member)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(member.Email))
                {
                    // Create a Admin user
                    var user = new ApplicationUser();
                    user.UserName = member.Email;
                    user.Email = member.Email;

                    string userPWD = $"{member.FirstName}123#";
                    try
                    {
                        var chkUser = await UserManager.CreateAsync(user, userPWD);

                        //Add default User to Role Admin
                        if (chkUser.Succeeded)
                        {
                            var result1 = UserManager.AddToRole(user.Id, member.MemberType);

                            member.MemberID = Helpers.MemberHelper.GenNewMemberId();
                            member.UserId = user.Id;
                            member.DateCreate = DateTime.Today;
                            db.Members.Add(member);
                            db.SaveChanges();
                            TempData["successMessage"] = "Registo Gravado com sucesso!";
                        }
                    }
                    catch (Exception ex)
                    {
                        TempData["errorMessage"] = "Não foi possível gravar o registo!";
                    }

                }
                else
                {
                    TempData["errorMessage"] = "Não foi possível gravar o registo!";
                }
                
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.FirstOrDefault(x=>x.MemberID == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            List<AspNetRole> roles = db.Roles.ToList();
            var memberType = new List<SelectListItem>();
            foreach (var item in roles)
            {
                memberType.Add(new SelectListItem { Value = item.Name, Text = item.Name });
            }
            ViewBag.MemberType = memberType;

            //ViewBag.MemberType = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Nationality = new SelectList(db.GeneralDatas.Where(x => x.ClassifierType == "COUNTRY").ToList(), "ID", "Description");
            // Creating a list of genders in Portuguese
            var genders = new List<SelectListItem>
            {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Feminino", Text = "Feminino" },
                // Add more options here as needed
            };

            // Passing the gender list to the view through ViewBag
            ViewBag.Gender = new SelectList(genders, "Value", "Text");
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,FirstName,OtherName,LastName,Gender,Nationality,Nuit,MemberType,Address,Email,Phone,DateCreate,StudentNumber,Bi,Status")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.FirstOrDefault(x=>x.MemberID == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
