using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodWeb.Models
{
    public class AppFoodDbContext:DbContext
    {
        public AppFoodDbContext():base("FoodDB")
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<SignupLogin> SignupLogin { get; set; }
        public DbSet<AdminLogin> adminLogin { get; set; }
        public DbSet<InvoiceModel> invoiceModel { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<ContactModel> contactModels { get; set; }
        public DbSet<BlogModel> blogModels { get; set; }

    }
}