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
    [Authorize(Roles = "Admins,Magic")]

    public class contactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: contacts
        public ActionResult Index()
        {
            var contacts = db.contacts ;

            return View(contacts.ToList());
        }

        // GET: contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacts contacts = db.contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // GET: contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( contacts contacts)
        {
            //string f = contacts.phone_num.ToString();
            //decimal ph = Convert.ToDecimal(f);
            //contacts.phone_num = ph;
            //f = contacts.telephone.ToString();
            //decimal pht = Convert.ToDecimal(f);
            //contacts.telephone = pht;
            contacts.date = DateTime.Now;
            contacts.userid = User.Identity.GetUserId();

            db.contacts.Add(contacts);
                db.SaveChanges();
            TempData.Clear();
            TempData["Success"] = "Success";
            return RedirectToAction("Index");
            
            
        }

        // GET: contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacts contacts = db.contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( contacts contacts)
        {
            if (ModelState.IsValid)
            {
                contacts.date = DateTime.Now;
                contacts.userid = User.Identity.GetUserId();

                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacts contacts = db.contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contacts contacts = db.contacts.Find(id);
            db.contacts.Remove(contacts);
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
