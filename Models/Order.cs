using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodWeb.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Qty { get; set; }
        public int Unit_Price { get; set; }
        public float Order_Bill { get; set; }
        public DateTime? Order_Date { get; set; }

        public int? FkProdId { get; set; }
        [ForeignKey("FkProdId")]
        public virtual Products prodcts { get; set; }

        public int? FkInvoiceID { get; set; }
        [ForeignKey("FkInvoiceID")]
        public virtual InvoiceModel invoices { get; set; }

       
    }
}