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
using System.IO;

namespace Magfinalproject.Controllers
{
    [Authorize(Roles = "Admins,Magic")]

    public class staffsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: staffs
    
        public ActionResult Index()
        {
            var staffs = db.staffs;

            return View(staffs.ToList());
        }
        public ActionResult log(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);

        }
        // GET: staffs/Details/5
        public ActionResult Details(int? id)
        {
            


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }
        [AllowAnonymous]
        public ActionResult Details_for_client(int? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        [Authorize]
        // GET: staffs/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(staff staff, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                var name = Convert.ToString(DateTime.Now.Millisecond);
                var mm = name + Path.GetFileName(upload.FileName);
                string path = Path.Combine(Server.MapPath("~/uploads"), mm);
                upload.SaveAs(path);

                staff.photo = mm;
                staff.userid = User.Identity.GetUserId();
                staff.date = DateTime.Now;

                staff.password = GetHashCode().ToString();
                staff.user_name = staff.name_en + GetHashCode().ToString().Substring(2,5);

                db.staffs.Add(staff);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }

            

            return View(staff);
        }

        // GET: staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            if (staff.userid == User.Identity.GetUserId())
            {
                return View(staff);
            }
            var ss = db.staffs.Where(d => d.userid.Contains(User.Identity.GetUserId()));
         
            
            return View(staff);
        }

        // POST: staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(staff staff, HttpPostedFileBase uploads )
        {

            if (ModelState.IsValid)
            {

                if (uploads != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(uploads.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), staff.photo);

                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    uploads.SaveAs(path);
                    staff.photo = m;
                    staff.userid = User.Identity.GetUserId();
                  
                }
                staff.password = GetHashCode().ToString();
                staff.user_name = staff.name_en + GetHashCode().ToString().Substring(2, 5);
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            

            return View(staff);
        }
        [AllowAnonymous]
        public ActionResult Edit_client(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            if (staff.userid == User.Identity.GetUserId())
            {
                return View(staff);
            }
            var ss = db.staffs.Where(d => d.userid.Contains(User.Identity.GetUserId()));

            

            return View(staff);
        }

        // POST: staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_client(int? id, staff staff, HttpPostedFileBase uploadss)
        {
            


            if (ModelState.IsValid)
            {

                if (uploadss != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(uploadss.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), staff.photo);

                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    uploadss.SaveAs(path);
                    staff.photo = m;
                    

                }
                staff.password = GetHashCode().ToString();
                staff.user_name = staff.name_en + GetHashCode().ToString().Substring(2, 5);
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Successc"] = "Successc";
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                staff staffs = db.staffs.Find(id);
                if (staffs == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Details_for_client",new { id = staffs.id });
            }
            
           

            return View(staff);
        }

        // GET: staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          staff  staff = db.staffs.Find(id);
           string  old = Path.Combine(Server.MapPath("~/uploads"), staff.photo);
            System.IO.File.Delete(old);
            db.staffs.Remove(staff);
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
