using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace SieuThiMVC.Models
{
  
    public class OrderDetail
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Order
    {
        public List<OrderDetail> Orders { get; set; }
    }
}