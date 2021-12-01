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
    public class HotelRoomController : Controller
    {
        private AnalyticsEntities db = new AnalyticsEntities();

        // GET: HotelRoom
        public ActionResult Index()
        {
            return View(db.HotelRooms.ToList());
        }

        // GET: HotelRoom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            if (hotelRoom == null)
            {
                return HttpNotFound();
            }
            return View(hotelRoom);
        }

        // GET: HotelRoom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelRoom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roomID,Roomname,Price")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                db.HotelRooms.Add(hotelRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelRoom);
        }

        // GET: HotelRoom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            if (hotelRoom == null)
            {
                return HttpNotFound();
            }
            return View(hotelRoom);
        }

        // POST: HotelRoom/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roomID,Roomname,Price")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelRoom);
        }

        // GET: HotelRoom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            if (hotelRoom == null)
            {
                return HttpNotFound();
            }
            return View(hotelRoom);
        }

        // POST: HotelRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            db.HotelRooms.Remove(hotelRoom);
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
