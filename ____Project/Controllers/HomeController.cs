using ____Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ____Project.Controllers
{
    public class HomeController : Controller
    {
        private AnalyticsEntities db = new AnalyticsEntities();


        public ActionResult Index()
        {

           
            return View(db.HotelGuests.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}