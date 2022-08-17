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

namespace Magfinalproject.Controllers
{
    [Authorize]
    public class asksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: asks
        public ActionResult Index()
        {
            var ask = db.asks ;

            return View(ask.ToList());
        }

        // GET: asks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ask ask = db.asks.Find(id);
            if (ask == null)
            {
                return HttpNotFound();
            }
            return View(ask);
        }

        // GET: asks/Create
        public ActionResult CreateC()
        {
            return View();
        }

        // POST: asks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateC( ask ask)
        {
            if (ModelState.IsValid)
            {
                ask.date = DateTime.Now;
                ask.priority = 50;
                db.asks.Add(ask);

                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }

            return View(ask);
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: asks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ask ask)
        {
            if (ModelState.IsValid)
            {
                ask.priority = 50;

                ask.date = DateTime.Now;
                db.asks.Add(ask);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }

            return View(ask);
        }

        // GET: asks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ask ask = db.asks.Find(id);
            if (ask == null)
            {
                return HttpNotFound();
            }
            return View(ask);
        }

        // POST: asks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ask ask)
        {
            if (ModelState.IsValid)
            {
                var m = float.Parse(ask.priority.ToString());
                ask.priority = m;
                ask.userid = User.Identity.GetUserId();

                db.Entry(ask).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(ask);
        }

        // GET: asks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ask ask = db.asks.Find(id);
            if (ask == null)
            {
                return HttpNotFound();
            }
            return View(ask);
        }

        // POST: asks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ask ask = db.asks.Find(id);
            db.asks.Remove(ask);
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
