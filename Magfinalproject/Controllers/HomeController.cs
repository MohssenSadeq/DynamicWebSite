using Magfinalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View(db.Categories.ToList());
        }
        public ActionResult makeques()
        {
            return View();
        }

        // POST: asks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult makeques([Bind(Include = "id,fname,lname,date,Email,subject,question,answer")] ask ask)
        {
            if (ModelState.IsValid)
            {
                ask.date = DateTime.Now;
                db.asks.Add(ask);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("makeques");
            }

            return View(ask);
        }
        [Authorize]
        public ActionResult magcontrol()
        {
            return View("magcontrol");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public PartialViewResult cardinfo()
        {
            List<Categorie> cardinfo = db.Categories.ToList();
            return PartialView("cardinfo", cardinfo);
        }

        public ActionResult Contact(int? id)
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
        public ActionResult local ()
        {
            return View();
        }
        public ActionResult student()
        {
            return View();
        }
        public ActionResult alumni()
        {
            return View();
        }
        public ActionResult lastnews()
        {
            return View();
        }
        public ActionResult lastevents()
        {
            return View();
        }
        //public ActionResult Search()
        //{
        //    return View();
        //}
        //    public ActionResult Search(string searchName)
        //    {
        //        var cres = db.colleges.Where(c => c.name.Contains(searchName));
        //        if(cres.LongCount()!=0)
        //        {
        //            return View("Csearch", cres);
        //        }
        //        var result = db.departments.Where(a => a.name.Contains(searchName)
        //        || a.college.name.Contains(searchName));
        //        if(result.LongCount() != 0)
        //          return View(result);

        //        var nse = db.cardinfoes.Where(a => a.title.Contains(searchName)
        //          ||a.Category.classname.ToString().Contains(searchName)
        //          || a.describtion.Contains(searchName));

        //        return View("Nsearch", nse);

        //    }


        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            ViewBag.searchname = searchName;
            return View();

        }
    }
    }