using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ____Project.Models;

namespace ____Project.Controllers
{
    public class HotelAdminsController : Controller
    {
        private AnalyticsEntities db = new AnalyticsEntities();

        // GET: HotelAdmins
        public ActionResult Index()
        {
            return View(db.HotelAdmins.ToList());
        }

        // GET: HotelAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelAdmin hotelAdmin = db.HotelAdmins.Find(id);
            if (hotelAdmin == null)
            {
                return HttpNotFound();
            }
            return View(hotelAdmin);
        }

        // GET: HotelAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,username,password")] HotelAdmin hotelAdmin)
        {
            if (ModelState.IsValid)
            {
                db.HotelAdmins.Add(hotelAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelAdmin);
        }

        // GET: HotelAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelAdmin hotelAdmin = db.HotelAdmins.Find(id);
            if (hotelAdmin == null)
            {
                return HttpNotFound();
            }
            return View(hotelAdmin);
        }

        // POST: HotelAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,username,password")] HotelAdmin hotelAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelAdmin);
        }

        // GET: HotelAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelAdmin hotelAdmin = db.HotelAdmins.Find(id);
            if (hotelAdmin == null)
            {
                return HttpNotFound();
            }
            return View(hotelAdmin);
        }

        // POST: HotelAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelAdmin hotelAdmin = db.HotelAdmins.Find(id);
            db.HotelAdmins.Remove(hotelAdmin);
            db.SaveChanges();
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
