using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Magfinalproject.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Magfinalproject.Controllers
{
    [Authorize(Roles = "Admins,Magic")]

    public class collegesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public JsonResult Check_clsname(String name, int? ID)
        {
            var validatename = db.colleges.FirstOrDefault(x => x.name.ToString() == name.ToString() && x.id != ID);

            if (validatename != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }
        [AllowAnonymous]
        public ActionResult allstaffs()
        {
            return View(db.colleges.ToList());
        }
        [AllowAnonymous]
        public ActionResult alldepartments()
        {
            return View(db.colleges.ToList());
        }
        // GET: colleges
        public ActionResult Index()
        {
            var colleges = db.colleges.Include(c=>c.center) ;

            return View(colleges.ToList());
        }
        [AllowAnonymous]
        public ActionResult IndexV(int? id)
        {
            return View(db.colleges.Where(a=>a.centerID==id).ToList());
        }

        [AllowAnonymous]
        public ActionResult DetailsV (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college college = db.colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college college = db.colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }
        [AllowAnonymous]
        public ActionResult staff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college college = db.colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // GET: colleges/Create
        public ActionResult Create()
        {
             ViewBag.centerID = new SelectList(db.centers, "ID", "classname");
            return View();
        }

        // POST: colleges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(college college,HttpPostedFileBase upload)
        {
            ViewBag.centerID = new SelectList(db.centers, "ID", "classname");
            if (ModelState.IsValid)
            {

                var name = Convert.ToString(DateTime.Now.Millisecond);
                var m = name + Path.GetFileName(upload.FileName);
                string path = Path.Combine(Server.MapPath("~/uploads"), m);
                upload.SaveAs(path);
                college.photo = m;
                college.date = DateTime.Now;
                college.userid = User.Identity.GetUserId();

                db.colleges.Add(college);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }
            ViewBag.centerID = new SelectList(db.centers, "ID", "classname",college.centerID);

            return View(college);
        }

        // GET: colleges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college college = db.colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            ViewBag.centerID = new SelectList(db.centers, "ID", "classname",college.centerID);
            return View(college);
        }

        // POST: colleges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(college college, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(upload.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), college.photo);
                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    upload.SaveAs(path);
                    college.photo = m;

                }
                college.date = DateTime.Now;
                college.userid = User.Identity.GetUserId();

                db.Entry(college).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");

            }
            ViewBag.centerID = new SelectList(db.centers, "ID", "classname", college.centerID);

            return View(college);
        }

        // GET: colleges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college college = db.colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            college colleges = db.colleges.Find(id);
            string old = Path.Combine(Server.MapPath("~/uploads"), colleges.photo);
            System.IO.File.Delete(old);
            college college = db.colleges.Find(id);
            db.colleges.Remove(college);
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
