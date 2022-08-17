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
using Microsoft.AspNet.Identity;

namespace Magfinalproject.Controllers
{
    [Authorize(Roles = "Admins,Magic")]

    public class centersController : Controller
    {               
        private ApplicationDbContext db = new ApplicationDbContext();
      
        public JsonResult Check_clsname(String classname, int? ID)
        {
            var validatename = db.centers.FirstOrDefault(x => x.classname.ToString() == classname.ToString() && x.ID != ID);

            if (validatename != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }
        // GET: centers
        public async Task<ActionResult> Index()
        {
            var centers = db.centers ;

            return View(await centers.ToListAsync());
        }

        // GET: centers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            center center = await db.centers.FindAsync(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // GET: centers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: centers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,classname")] center center)
        {
            if (ModelState.IsValid)
            {
                center.date = DateTime.Now;
                center.userid = User.Identity.GetUserId();

                db.centers.Add(center);
                await db.SaveChangesAsync();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }

            return View(center);
        }

        // GET: centers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            center center = await db.centers.FindAsync(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // POST: centers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,classname,date")] center center)
        {
            if (ModelState.IsValid)
            {
                center.userid = User.Identity.GetUserId();

                db.Entry(center).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            return View(center);
        }

        // GET: centers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            center center = await db.centers.FindAsync(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }
       
        // POST: centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            center center = await db.centers.FindAsync(id);
            db.centers.Remove(center);
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
