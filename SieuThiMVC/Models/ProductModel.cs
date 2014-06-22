using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace SieuThiMVC.Models
{
    public class SortOfProduct
    {
        public int ID { set; get; }
        public string Name { set; get; }
    }
    public class SortOfProductModel
    {
        [Display(Name = "Loại hàng hóa")]
        public string SProduct { set; get; }
    }
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public Int64 Cost { get; set; }
        public string Discription { get; set; }
        public string ImgLink { get; set; }
        public int CategoryID { get; set; }
    }
    public class ProductModel
    {
        public int ID;

        [Required]
        [Display(Name = "Loại hàng hóa")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Tên hàng hóa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Giá")]
        public Int64 Cost { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string Discription { get; set; }

        [Display(Name = "Hình ảnh")]
        public string ImgLink { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                ID = ID,
                Name = Name,
                Cost = Cost,
                Discription = Discription,
                ImgLink = ImgLink,
                CategoryID = CategoryID
            };
        }
    }
    public class ListProduct
    {
        public int SelectedID{set;get;}
        public List<Product> MyList{set;get;}
    }
    public class CommentModel
    {
        public string Comment { get; set; }

        public int  PID;
        public int UID;
        public string Name;
    }
    public class Comment
    {
        public string Context { get; set; }
        public DateTime Date { get; set; }
        public int PID;
        public int UID;
        public string Name;
    }

}
