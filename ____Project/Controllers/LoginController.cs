using ____Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication37.Controllers
{



    public class LoginController : Controller
    {
        AnalyticsEntities db = new AnalyticsEntities();



        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HotelAdmin objchk)
        {

            if (ModelState.IsValid)
            {
                using (AnalyticsEntities db = new AnalyticsEntities())
                {
                    var obj = db.HotelAdmins.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();



                    if (obj != null)
                    {
                        Session["UserID"] = obj.userID.ToString();
                        Session["Username"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                       
                        ModelState.AddModelError("", "The username or password is incorrect");

                    }


                }
            }

            return View(objchk);
        }
    }
}