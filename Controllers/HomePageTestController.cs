using FoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWeb.Controllers
{
    public class HomePageTestController : Controller
    {
        AppFoodDbContext db = new AppFoodDbContext();
        // GET: HomePageTest
        public ActionResult Index()
        {
                List<Products> products = db.Products.ToList<Products>();
                return View(products);
           
          
        }
    }
}