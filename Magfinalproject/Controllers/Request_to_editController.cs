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
using System.Net.Mail;
using Microsoft.AspNet.Identity;

namespace Magfinalproject.Controllers
{
    [Authorize(Roles = "Admins,Magic")]

    public class Request_to_editController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Request_to_edit
        public ActionResult Index()
        {
            var request_to_edit = db.Request_to_edit.Include(r => r.staff) ;

            return View(request_to_edit.ToList());
        }

        // GET: Request_to_edit/Details/5
        public ActionResult Details(int? id)
        {
           

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request_to_edit request_to_edit = db.Request_to_edit.Find(id);
            if (request_to_edit == null)
            {
                return HttpNotFound();
            }
            return View(request_to_edit);
        }
        [AllowAnonymous]
        // GET: Request_to_edit/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff request_to_edit = db.staffs.Find(id);
            if (request_to_edit == null)
            {
                return HttpNotFound();
            }
            ViewBag.staffid = request_to_edit.id;
           

            return View();
        }

        // POST: Request_to_edit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, Request_to_edit request_to_edit, HttpPostedFileBase upload, HttpPostedFileBase uploadu)
        {
            if (ModelState.IsValid)
            {

                staff staff = db.staffs.Find(id);
                if (staff == null)
                {
                    return HttpNotFound();
                }
                ViewBag.staffid = staff.id;

                var name = Convert.ToString(DateTime.Now.Millisecond);
                var m = name + Path.GetFileName(upload.FileName);
                string path = Path.Combine(Server.MapPath("~/uploads"), m);
                upload.SaveAs(path);
                request_to_edit.pic = m;
                request_to_edit.states = false;
                var nameu = Convert.ToString(DateTime.Now.Millisecond);
                var mu = nameu + Path.GetFileName(uploadu.FileName);
                string pathu = Path.Combine(Server.MapPath("~/uploads"), mu);
                uploadu.SaveAs(pathu);
                request_to_edit.picuni = mu;
                var ttt = DateTime.Now;
                ttt.ToUniversalTime();
                request_to_edit.date = ttt;

                request_to_edit.staffid = staff.id;

                db.Request_to_edit.Add(request_to_edit);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }

            ViewBag.staffid = new SelectList(db.staffs, "id", "name", request_to_edit.staffid);
            

            return View(request_to_edit);
        }

        public ActionResult Edit_confirm (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request_to_edit request_to_edit = db.Request_to_edit.Find(id);
            if (request_to_edit == null)
            {
                return HttpNotFound();
            }
            ViewBag.staffid = new SelectList(db.staffs, "id", "name", request_to_edit.staffid);

            return View(request_to_edit);
        }

        // POST: Request_to_edit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_confirm(int? id,Request_to_edit request_to_edit)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             request_to_edit = db.Request_to_edit.Find(id);
       
            ViewBag.staffid = new SelectList(db.staffs, "id", "name", request_to_edit.staffid);
            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("mohsensadeq@alsalahiexco.net", "Mkks1994");
            mail.From = new MailAddress("mohsensadeq@alsalahiexco.net");
            mail.To.Add(request_to_edit.Email);
            mail.Subject =" معلومات حسابك في شـركة الصـلاحـي للصرافة والتحويلات ";
            mail.IsBodyHtml = true;
            string body = "اسم المرسل: شـركة الصـلاحـي للصرافة والتحويلات "+"<br />" +
                            "mohsensadeq@alsalahiexco.net:بريد المرسل<b>" + "<br />" +"<b/>.عنوان الرسالة: معلومات حسابك في شـركة الصـلاحـي للصرافة والتحويلات " + "<br />"+  "<b>نص الرسالة: شكرا لتواصلك معنا " + request_to_edit.dgreeid +" : "+request_to_edit.fullName+ "<br/>يسرنا أنك أصبحت أحد مستخدمي موقع شـركة الصـلاحـي للصرافة والتحويلات" + " يمكنك أستخدام أسم المستخدم وكلمة المرور التاليتين لتعديل ملفك الشخصي على موقع الشركة " + "<br />"+request_to_edit.staff.user_name+" : أسم المستخدم "+"<br/>"+ request_to_edit.staff.password+" : كلمة المرور" + "<br/>.تمنياتنا لك بالتوفيق" ;
            mail.Body = body;
            var smtpClient = new SmtpClient("smtp.alsalahiexco.net", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);
            request_to_edit.states=true;
            request_to_edit.userid = User.Identity.GetUserId();

            db.Entry(request_to_edit).State = EntityState.Modified;
                db.SaveChanges();
            TempData.Clear();
            TempData["Successm"] = "Successm";
            return RedirectToAction("Index");
                                      
        }

    

        // POST: Request_to_edit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        // GET: Request_to_edit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request_to_edit request_to_edit = db.Request_to_edit.Find(id);
            if (request_to_edit == null)
            {
                return HttpNotFound();
            }
            ViewBag.staffid = new SelectList(db.staffs, "id", "name", request_to_edit.staffid);

            return View(request_to_edit);
        }

        // POST: Request_to_edit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int?id, Request_to_edit request_to_edit, HttpPostedFileBase upload, HttpPostedFileBase uploadu)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             request_to_edit = db.Request_to_edit.Find(id);
            if (request_to_edit == null)
            {
                return HttpNotFound();
            }
            ViewBag.staffid = new SelectList(db.staffs, "id", "name", request_to_edit.staffid);
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(upload.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), request_to_edit.pic);
                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    upload.SaveAs(path);
                    request_to_edit.pic = m;

                }
                if (uploadu != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(uploadu.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), request_to_edit.picuni);
                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    uploadu.SaveAs(path);
                    request_to_edit.picuni = m;

                }

                request_to_edit.date = DateTime.Now;
                request_to_edit.userid = User.Identity.GetUserId();

                db.Entry(request_to_edit).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            ViewBag.staffid = new SelectList(db.staffs, "id", "name", request_to_edit.staffid);
            //ViewBag.dgreeid = new SelectList(db.dgrees, "name", request_to_edit.dgreeid);

            return View(request_to_edit);
        }

        // GET: Request_to_edit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request_to_edit request_to_edit = db.Request_to_edit.Find(id);
            if (request_to_edit == null)
            {
                return HttpNotFound();
            }
            return View(request_to_edit);
        }

        // POST: Request_to_edit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request_to_edit request_to_edit = db.Request_to_edit.Find(id);
             string old = Path.Combine(Server.MapPath("~/uploads"), request_to_edit.pic);
            System.IO.File.Delete(old);
            string oldu = Path.Combine(Server.MapPath("~/uploads"), request_to_edit.picuni);
            System.IO.File.Delete(oldu);
            db.Request_to_edit.Remove(request_to_edit);
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
