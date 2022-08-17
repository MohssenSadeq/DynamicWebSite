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

    public class agentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

      
        public ActionResult Index()
        {
            var agents = db.agents;

            return View(agents.ToList());
        }
        [AllowAnonymous]
        public ActionResult allnews()
        {
            
            var agents = db.agents;

            return View(agents.ToList());
        }
        // GET: agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agent agent = db.agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }
        //[AllowAnonymous]
        //public ActionResult Detailspost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    agent agent = db.agents.Find(id);
        //    if (agent == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(agent);
        //}
        [AllowAnonymous]
        public ActionResult detailspost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agent agent = db.agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }


        // GET: agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(agent agent, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                var ttt = DateTime.Now;
                ttt.ToUniversalTime();
                agent.date = ttt;
                agent.userid = User.Identity.GetUserId();

                db.agents.Add(agent);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");

            }

            return View(agent);
        }

        // GET: agents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agent agent = db.agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(agent agent, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

            
                agent.userid = User.Identity.GetUserId();

                db.Entry(agent).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agent agent = db.agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            agent agent = db.agents.Find(id);
            
            db.agents.Remove(agent);
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
