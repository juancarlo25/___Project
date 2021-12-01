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
    public class HotelGuestsController : Controller
    {
        private AnalyticsEntities db = new AnalyticsEntities();

        // GET: HotelGuests
        public ActionResult Index()
        {
            return View(db.HotelGuests.ToList());
        }

        // GET: HotelGuests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelGuest hotelGuest = db.HotelGuests.Find(id);
            if (hotelGuest == null)
            {
                return HttpNotFound();
            }
            return View(hotelGuest);
        }

        // GET: HotelGuests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelGuests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestID,Firstname,Lastname,Roomname,CheckIN,CheckOUT,Total")] HotelGuest hotelGuest)
        {
            if (ModelState.IsValid)
            {
                db.HotelGuests.Add(hotelGuest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelGuest);
        }

        // GET: HotelGuests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelGuest hotelGuest = db.HotelGuests.Find(id);
            if (hotelGuest == null)
            {
                return HttpNotFound();
            }
            return View(hotelGuest);
        }

        // POST: HotelGuests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestID,Firstname,Lastname,Roomname,CheckIN,CheckOUT,Total")] HotelGuest hotelGuest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelGuest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelGuest);
        }

        // GET: HotelGuests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelGuest hotelGuest = db.HotelGuests.Find(id);
            if (hotelGuest == null)
            {
                return HttpNotFound();
            }
            return View(hotelGuest);
        }

        // POST: HotelGuests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelGuest hotelGuest = db.HotelGuests.Find(id);
            db.HotelGuests.Remove(hotelGuest);
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
