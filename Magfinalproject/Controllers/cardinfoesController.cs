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
{         [Authorize]
    public class cardinfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            var cardinfoes = db.cardinfoes.Include(c => c.Category);

            return View(cardinfoes.ToList());
        }

        // GET: cardinfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardinfo cardinfo = db.cardinfoes.Find(id);
            if (cardinfo == null)
            {
                return HttpNotFound();
            }
            return View(cardinfo);
        }
        [AllowAnonymous]
        public ActionResult Detailspost (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardinfo cardinfo = db.cardinfoes.Find(id);
            if (cardinfo == null)
            {
                return HttpNotFound();
            }
            return View(cardinfo);
        }
        [AllowAnonymous]
        public ActionResult Detailinfo (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardinfo cardinfo = db.cardinfoes.Find(id);
            if (cardinfo == null)
            {
                return HttpNotFound();
            }
            return View(cardinfo);
        }


        // GET: cardinfoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "classname");

            return View();
        }

        // POST: cardinfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cardinfo cardinfo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                var name = Convert.ToString(DateTime.Now.Millisecond);
                var m = name + Path.GetFileName(upload.FileName);
                string path = Path.Combine(Server.MapPath("~/uploads"), m);
                upload.SaveAs(path);
                cardinfo.pic = m;
                var ttt = DateTime.Now;
                ttt.ToUniversalTime();
                cardinfo.date = ttt;
                if (User.Identity.GetUserId() != null)
                {
                    cardinfo.userid = User.Identity.GetUserId();

                }

                db.cardinfoes.Add(cardinfo);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");

            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "classname", cardinfo.CategoryID);

            return View(cardinfo);
        }

        // GET: cardinfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardinfo cardinfo = db.cardinfoes.Find(id);
            if (cardinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "classname", cardinfo.CategoryID);
            return View(cardinfo);
        }

        // POST: cardinfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cardinfo cardinfo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(upload.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), cardinfo.pic);
                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    upload.SaveAs(path);
                    cardinfo.pic = m;

                }
                cardinfo.userid = User.Identity.GetUserId();

                db.Entry(cardinfo).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";

                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "classname", cardinfo.CategoryID);
            return View(cardinfo);
        }

        // GET: cardinfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardinfo cardinfo = db.cardinfoes.Find(id);
            if (cardinfo == null)
            {
                return HttpNotFound();
            }
            return View(cardinfo);
        }

        // POST: cardinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cardinfo cardinfo = db.cardinfoes.Find(id);
            string old = Path.Combine(Server.MapPath("~/uploads"), cardinfo.pic);
            System.IO.File.Delete(old);
          
            db.cardinfoes.Remove(cardinfo);
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
