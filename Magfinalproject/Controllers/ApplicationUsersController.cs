using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Magfinalproject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Magfinalproject.Controllers
{
    [Authorize(Roles = "Admins,Magic")]
    public class ApplicationUsersController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
        //public ApplicationUsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}
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
        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.Users.Where(a=>a.UserType!="Magic").ToList());
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserType = new SelectList(db.Roles.Where(a=>a.Name!="Magic").ToList(), "Name", "Name");
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserType,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser User)
        {
            var rol = db.Roles.Where(a => a.Name == User.UserType).FirstOrDefault();
            
            ViewBag.UserType = new SelectList(db.Roles.ToList(), "Name", "Name");
            if (ModelState.IsValid)
            {
                
              var ddd=  UserManager.PasswordHasher.HashPassword(User.PasswordHash);

                User.PasswordHash = ddd;
              var se=  ddd.FirstOrDefault().GetHashCode();
                var see= UserManager.PasswordHasher.HashPassword(se.ToString());
                User.SecurityStamp = see.ToString();
                db.Users.Add(User);
                Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole d = new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole();
                d.UserId = User.Id;
                d.RoleId =rol.Id ;
                User.LockoutEnabled = true;
                User.Roles.Add(d);
                TempData.Clear();
                TempData["Success"] = "Success";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(User);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.cide= UserManager.GeneratePasswordResetToken(User.Identity.GetUserId());
            ViewBag.UserType = new SelectList(db.Roles.ToList().Where(a => a.Name != "Magic"), "Name", "Name");
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserType,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,nikname")] ApplicationUser applicationUser)
        {
            var rol = db.Roles.Where(a => a.Name == applicationUser.UserType).FirstOrDefault();
            
            ViewBag.UserType = new SelectList(db.Roles.ToList().Where(a => a.Name != "Magic"), "Name", "Name");
            if (ModelState.IsValid)
            {
                var ddd = UserManager.PasswordHasher.HashPassword(applicationUser.PasswordHash);

                applicationUser.PasswordHash = ddd;
                applicationUser.nikname = applicationUser.nikname;
                var d = UserManager.UpdateSecurityStamp(applicationUser.Id);
                applicationUser.SecurityStamp = d.ToString();
               
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            TempData.Clear();
            TempData["Delete"] = "Delete";
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
