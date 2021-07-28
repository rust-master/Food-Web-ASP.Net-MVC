using FoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWeb.Controllers
{
    public class AdminController : Controller
    {
        AppFoodDbContext db = new AppFoodDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if(adminInCookie != null)
            {
                return View();
            }
            else
            {
                var userInCookie = Request.Cookies["UserInfo"];
                if (userInCookie != null)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    return RedirectToAction("LoginAdmin", "Admin");
                }
            }

        }
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                return RedirectToAction("Index", "Admin"); ;
            }
            else
            {
                var userInCookie = Request.Cookies["UserInfo"];
                if (userInCookie != null)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    return View();
                }
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(AdminLogin model)
        {
            var data = db.adminLogin.Where(s => s.Email.Equals(model.Email) && s.Password.Equals(model.Password)).ToList();
            if (data.Count() > 0)
            {
                HttpCookie cooskie = new HttpCookie("AdminInfo");
                cooskie.Values["idAdmin"] = Convert.ToString(data.FirstOrDefault().adminid);
                cooskie.Values["Email"] = Convert.ToString(data.FirstOrDefault().Email);
                cooskie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cooskie);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Message = "Login failed";
                return RedirectToAction("LoginAdmin");
            }
        }
        public ActionResult LogoutAdmin()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminInfo"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["AdminInfo"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction("LoginAdmin");
        }

        public ActionResult ListOfOrders()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                float t = 0;
                List<Order> order = db.orders.ToList<Order>();
                foreach(var item in order)
                {
                    t += item.Order_Bill;
                }
                TempData["OrderTotal"] = t;
                return View(order);
            }
            else
            {
                var userInCookie = Request.Cookies["UserInfo"];
                if (userInCookie != null)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    return RedirectToAction("LoginAdmin", "Admin");
                }
            }
        }
        public ActionResult ListOfInvoices()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                float t = 0;
                List<InvoiceModel> invoice = db.invoiceModel.ToList<InvoiceModel>();
                
                foreach (var item in invoice)
                {
                    t += item.Total_Bill;
                   
                    
                }
                TempData["InvoiceTotal"] = t;
                return View(invoice);
            }
            else
            {
                var userInCookie = Request.Cookies["UserInfo"];
                if (userInCookie != null)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    return RedirectToAction("LoginAdmin", "Admin");
                }
            }
        }
    }
}