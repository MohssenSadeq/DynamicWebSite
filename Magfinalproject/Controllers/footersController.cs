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

    public class footersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult Check_clsname(String title, int? ID)
        {
            var validatename = db.footers.FirstOrDefault(x=>x.title.ToString() == title.ToString() && x.ID != ID);

            if (validatename != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Index()
        {
            var footers = db.footers ;

            return View(footers.ToList());
        }
        [AllowAnonymous]
        public ActionResult allnews(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footer footer = db.footers.Find(id);
            var footers = db.footers.Where(a => a.mainfoot == footer.mainfoot);
            ViewBag.mo = footer.mainfoot;

            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footers.ToList());
        }
        // GET: footers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footer footer = db.footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }
        //[AllowAnonymous]
        //public ActionResult Detailspost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    footer footer = db.footers.Find(id);
        //    if (footer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(footer);
        //}
        [AllowAnonymous]
        public ActionResult detailspost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footer footer = db.footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }


        // GET: footers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: footers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(footer footer, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    upload.SaveAs(path);
                    footer.pic = m;
                }
              
                var ttt = DateTime.Now;
                ttt.ToUniversalTime();
                footer.date = ttt;
                footer.userid = User.Identity.GetUserId();

                db.footers.Add(footer);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");

            }

            return View(footer);
        }

        // GET: footers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footer footer = db.footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: footers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(footer footer, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(upload.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), footer.pic);
                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    upload.SaveAs(path);
                    footer.pic = m;

                }
                footer.userid = User.Identity.GetUserId();

                db.Entry(footer).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(footer);
        }

        // GET: footers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footer footer = db.footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: footers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {             footer footer = db.footers.Find(id);
            if ( footer.pic!= null)
            {
            
                string old = Path.Combine(Server.MapPath("~/uploads"), footer.pic);
                System.IO.File.Delete(old);
            }
            db.footers.Remove(footer);
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
