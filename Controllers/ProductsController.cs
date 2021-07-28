using FoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWeb.Controllers
{
    public class ProductsController : Controller
    {
        AppFoodDbContext db = new AppFoodDbContext();
        // GET: Products
        public ActionResult Index()
        {
                List<Products> products = db.Products.ToList<Products>();
                return View(products);
           
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public ActionResult CreateNewProduct()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
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
        [HttpPost]
        public ActionResult CreateNewProduct(HttpPostedFileBase file , Products products)
        {
            if(file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string filename= file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    products.ProductPicture = "Images/"+ filename;
                    db.Products.Add(products);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            } 
            return View();
        }
    
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                Products products = db.Products.Find(id);
                if (products == null)
                {
                    return HttpNotFound();
                }
                return View(products);
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
        [HttpPost]
        public ActionResult EditProduct(HttpPostedFileBase file, Products products)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string filename = file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    products.ProductPicture = "Images/" + filename;
                    db.Entry(products).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("ViewProductsAdmin", "Products");
        }
        public ActionResult ViewProductsAdmin()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                List<Products> products = db.Products.ToList<Products>();
                return View(products);
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
  
        public ActionResult addToCart(int? Id)
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var userInCookie = Request.Cookies["UserInfo"];
                if (userInCookie != null)
                {
                    Products products = db.Products.Find(Id);
                    return View(products);

                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
        
        }

        List<Cart> li = new List<Cart>();

        [HttpPost]
        public ActionResult addToCart(int Id, string number)
        {
            var userInCookie = Request.Cookies["UserInfo"];
            if (userInCookie != null)
            {
                Products products = db.Products.Find(Id);
                Cart cart = new Cart();
                cart.productId = products.id;
                cart.productName = products.ProductName;
                cart.productPic = products.ProductPicture;
                cart.price = products.ProductPrice;
                cart.qty = Convert.ToInt32(number);
                cart.bill = cart.price * cart.qty;
                if (TempData["cart"] == null)
                {
                    li.Add(cart);
                    TempData["cart"] = li;
                }
                else
                {
                    //List<Cart> li2 = TempData["cart"] as List<Cart>;
                    //li2.Add(cart);
                    //TempData["cart"] = li2;
                    List<Cart> li2 = TempData["cart"] as List<Cart>;
                    int flag = 0;
                    foreach(var item in li2)
                    {
                        if(item.productId == cart.productId)
                        {
                            item.qty += cart.qty;
                            item.bill += cart.bill;
                            flag = 1;
                        }
                    }
                    if(flag==0)
                    {
                        li2.Add(cart);
                    }
                    TempData["cart"] = li2;
                }

                TempData.Keep();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult Checkout()
        {
            var adminInCookie = Request.Cookies["AdminInfo"];
            if (adminInCookie != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var userInCookie = Request.Cookies["UserInfo"];
                if (userInCookie != null)
                {
                    TempData.Keep();
                    if (TempData["cart"] != null)
                    {
                        float x = 0;
                        List<Cart> li2 = TempData["cart"] as List<Cart>;
                        foreach (var item in li2)
                        {
                            x += item.bill;
                        }
                        TempData["total"] = x;
                    }
                    TempData.Keep();
                    return View();

                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }

           
        }
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var userInCookie = Request.Cookies["UserInfo"];
            int iduser = Convert.ToInt32(userInCookie["idUser"]);
            List<Cart> li = TempData["cart"] as List<Cart>;
            InvoiceModel invoice = new InvoiceModel();
            invoice.FKUserID = iduser;
            invoice.DateInvoice = System.DateTime.Now;
            invoice.Total_Bill = (float)TempData["Total"];
            db.invoiceModel.Add(invoice);
            db.SaveChanges();
            foreach(var item in li)
            {
                Order odr = new Order();
                odr.FkProdId = item.productId;
                odr.FkInvoiceID = invoice.ID;
                odr.Order_Date = System.DateTime.Now;
                odr.Qty = item.qty;
                odr.Unit_Price = (int)item.price;
                odr.Order_Bill = item.bill;
                db.orders.Add(odr);
                db.SaveChanges();
            }
            TempData.Remove("total");
            TempData.Remove("cart");
            TempData.Keep();
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int? id)
        {
            List<Cart> li2 = TempData["cart"] as List<Cart>;
            Cart c = li2.Where(x => x.productId == id).SingleOrDefault();
            li2.Remove(c);
            float h = 0;
            foreach(var item in li2)
            {
                h += item.bill;
            }
            TempData["total"] = h;
            return RedirectToAction("Checkout");
        }
    }
}