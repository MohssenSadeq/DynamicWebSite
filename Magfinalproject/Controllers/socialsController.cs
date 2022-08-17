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

    public class socialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: socials
        public ActionResult Index()
        {
            var socials = db.socials ;
            return View(socials.ToList());
        }

        // GET: socials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            social social = db.socials.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // GET: socials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: socials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(social social)
        {
            if (ModelState.IsValid)
            {
                social.date = DateTime.Now;
                var m = social.social_name.ToString();
             

                switch (m)
                {
                    case "فيسبوك":
                        {
                            social.icon = "facebook";
                            break;
                        }
                    case "تويتر":
                        {
                            social.icon = "twitter";
                            break;
                        }
                    case "إنستجرام":
                        {
                            social.icon = "instagram";
                            break;
                        }
                    case "لينكن":
                        {
                            social.icon = "linkedin";
                            break;
                        }
                    case "جوجل_بلس":
                        {
                            social.icon = "google-plus";
                            break;
                        }
                    case "بينترست":
                        {
                            social.icon = "pinterest";
                            break;
                        }
                    case "جيت_هب":
                        {
                            social.icon = "github";
                            break;
                        }
                    case "تمبلر":
                        {
                            social.icon = "tumblr";
                            break;
                        }
                    case "فليكر":
                        {
                            social.icon = "flickr";
                            break;
                        }
                    default:
                        break;
                }
                social.userid = User.Identity.GetUserId();

                db.socials.Add(social);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }

            return View(social);
        }

        // GET: socials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            social social = db.socials.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: socials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,social_name,link,icon,date")] social social)
        {
            if (ModelState.IsValid)
            {
                social.date = DateTime.Now;
                var m = social.social_name.ToString();

                switch (m)
                {
                    case "فيسبوك":
                        {
                            social.icon = "facebook";
                            break;
                        }
                    case "تويتر":
                        {
                            social.icon = "twitter";
                            break;
                        }
                    case "إنستجرام":
                        {
                            social.icon = "instagram";
                            break;
                        }
                    case "لينكن":
                        {
                            social.icon = "linkedin";
                            break;
                        }
                    case "جوجل_بلس":
                        {
                            social.icon = "google-plus";
                            break;
                        }
                    case "بينترست":
                        {
                            social.icon = "pinterest";
                            break;
                        }
                    case "جيت_هب":
                        {
                            social.icon = "github";
                            break;
                        }
                    case "تمبلر":
                        {
                            social.icon = "tumblr";
                            break;
                        }
                    case "فليكر":
                        {
                            social.icon = "flickr";
                            break;
                        }
                    default:
                        break;
                }
                social.userid = User.Identity.GetUserId();

                db.Entry(social).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(social);
        }

        // GET: socials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            social social = db.socials.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            social social = db.socials.Find(id);
            db.socials.Remove(social);
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
