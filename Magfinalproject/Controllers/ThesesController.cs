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
{   [Authorize]
    public class ThesesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Theses
        public async Task<ActionResult> Index(int? id)
        {
            var theses = db.Theses.Include(t => t.department).Where(a => a.departmentID == id) ;

            return View(await theses.ToListAsync());
        }
        [AllowAnonymous]
        public ActionResult Indexv()
        {

            return View(db.colleges.ToList());
        }
        [AllowAnonymous]
        public ActionResult Indexvd()
        {

            return View(db.colleges.ToList());
        }

        // GET: Theses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thesis thesis = await db.Theses.FindAsync(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            return View(thesis);
        }

        // GET: Theses/Create
        public ActionResult Create()
        {
            ViewBag.departmentID = new SelectList(db.departments, "id", "name");
            return View();
        }

        // POST: Theses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,departmentID,name,title,supervisor,thesistype")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                thesis.date = DateTime.Now;
                thesis.userid = User.Identity.GetUserId();

                db.Theses.Add(thesis);
                await db.SaveChangesAsync();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index", new { id = thesis.departmentID });
            }

            ViewBag.departmentID = new SelectList(db.departments, "id", "name", thesis.departmentID);
            return View(thesis);
        }

        // GET: Theses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thesis thesis = await db.Theses.FindAsync(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            ViewBag.departmentID = new SelectList(db.departments, "id", "name", thesis.departmentID);
            return View(thesis);
        }

        // POST: Theses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,departmentID,name,title,supervisor,date,thesistype")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                thesis.userid = User.Identity.GetUserId();

                db.Entry(thesis).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index", new { id = thesis.departmentID });
            }
            ViewBag.departmentID = new SelectList(db.departments, "id", "name", thesis.departmentID);
            return View(thesis);
        }

        // GET: Theses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thesis thesis = await db.Theses.FindAsync(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            return View(thesis);
        }

        // POST: Theses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Thesis thesis = await db.Theses.FindAsync(id);
            db.Theses.Remove(thesis);
            await db.SaveChangesAsync();
            TempData.Clear();
            TempData["Delete"] = "Delete";
            return RedirectToAction("Index", new { id = thesis.departmentID });
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
