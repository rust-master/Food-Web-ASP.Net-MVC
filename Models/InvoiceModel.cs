using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodWeb.Models
{
    public class InvoiceModel
    {
        [Key]
        public int ID { get; set; }
       
        public DateTime? DateInvoice { get; set; }
        public float Total_Bill { get; set; }

        public int? FKUserID { get; set; }
        [ForeignKey("FKUserID")]
        public virtual SignupLogin user { get; set; }


    }
}