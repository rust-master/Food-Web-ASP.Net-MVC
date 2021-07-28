using FoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWeb.Controllers
{
    public class InformationController : Controller
    {
        AppFoodDbContext db = new AppFoodDbContext();
        // GET: Information
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactModel contact)
        {
            db.contactModels.Add(contact);
            db.SaveChanges();
            return View();
        }
        public ActionResult MessageList()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                List<ContactModel> contacts = db.contactModels.ToList<ContactModel>();
                return View(contacts);
                
            }
            else
            {
                var userInCookie = Request.Cookies["UserInfo"];
                if (userInCookie != null)
                {
                    return RedirectToAction("Products", "Index");

                }
                else
                {
                    return RedirectToAction("LoginAdmin", "Admin");
                }
            }
        }
        public ActionResult AboutUs()
        {

            return View();
        }
        public ActionResult Blogs()
        {

            return View();
        }

    }
}