using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Magfinalproject.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Magfinalproject.Controllers
{          [Authorize]
    public class CarsualsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carsuals
        public async Task<ActionResult> Index()
        {
            var Carsuals = db.Carsuals ;
            return View(await Carsuals.ToListAsync());
        }

        // GET: Carsuals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carsual carsual = await db.Carsuals.FindAsync(id);
            if (carsual == null)
            {
                return HttpNotFound();
            }
            return View(carsual);
        }
        [AllowAnonymous]
        public ActionResult Detailspost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carsual cardinfo = db.Carsuals.Find(id);
            if (cardinfo == null)
            {
                return HttpNotFound();
            }
            return View(cardinfo);
        }

        // GET: Carsuals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carsuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Carsual carsual, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var name = Convert.ToString(DateTime.Now.Millisecond);
                var m = name + Path.GetFileName(upload.FileName);
                string path = Path.Combine(Server.MapPath("~/uploads"), m);
                upload.SaveAs(path);
                carsual.pic = m;
                var ttt = DateTime.Now;
                ttt.ToUniversalTime();
                carsual.date = ttt;
                carsual.userid = User.Identity.GetUserId();

                db.Carsuals.Add(carsual);
                await db.SaveChangesAsync();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }

            return View(carsual);
        }

        // GET: Carsuals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carsual carsual = await db.Carsuals.FindAsync(id);
            if (carsual == null)
            {
                return HttpNotFound();
            }
            return View(carsual);
        }

        // POST: Carsuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Carsual carsual, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(upload.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), carsual.pic);
                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    upload.SaveAs(path);
                    carsual.pic = m;

                }
                carsual.userid = User.Identity.GetUserId();

                db.Entry(carsual).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(carsual);
        }

        // GET: Carsuals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carsual carsual = await db.Carsuals.FindAsync(id);
            if (carsual == null)
            {
                return HttpNotFound();
            }
            return View(carsual);
        }

        // POST: Carsuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Carsual carsual = await db.Carsuals.FindAsync(id);
            string old = Path.Combine(Server.MapPath("~/uploads"), carsual.pic);
            System.IO.File.Delete(old);
           
            db.Carsuals.Remove(carsual);
            await db.SaveChangesAsync();
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
