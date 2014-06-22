using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
namespace SieuThiMVC.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            var model = DataAccess.ProductsDBO.GetProduct(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateComment(Models.CommentModel model, int id)
        {
            model.UID = WebSecurity.CurrentUserId;
            model.PID = id;
            DataAccess.ProductsDBO.PostComment(model);
            return View();
        }
       
        public PartialViewResult SelectCategory(int id)
        {
            List<Models.Product> products = null;
            products = DataAccess.ProductsDBO.GetProductsByCategory(id);
            return PartialView("_product", new Models.ListProduct { SelectedID = id, MyList = products });
        }

        public PartialViewResult PurchaseProduct(int id)
        {
            var order = (Models.Order)Session["Cart"];
            var isExistProduct = false;
            foreach (var item in order.Orders)
            {
                if (item.Product.ID == id)
                {
                    isExistProduct = true;
                    item.Quantity++;
                }
            }
            if (!isExistProduct)
            {
                var orderdetail = new Models.OrderDetail
                {
                    Quantity = 1,
                    Product = DataAccess.ProductsDBO.GetProduct(id).ToProduct()
                };
                ((Models.Order)Session["Cart"]).Orders.Add(orderdetail);
            }
            return PartialView("_ShoppingCart", Session["Cart"]);
        }
        public PartialViewResult AddQuantity(int id)
        {
            var order = (Models.Order)Session["Cart"];
            foreach(var item in order.Orders)
            {
                if (item.Product.ID == id)
                {
                    item.Quantity++;
                    break;
                }
            }
            return PartialView("_ShoppingCart", order);
        }
        public PartialViewResult DecreaseQuantity(int id)
        {
            var order = (Models.Order)Session["Cart"];
            foreach (var item in order.Orders)
            {
                if (item.Product.ID == id)
                {
                    item.Quantity--;
                    if (item.Quantity == 0)
                    {
                        order.Orders.Remove(item);
                    }
                    break;
                }
            }
            return PartialView("_ShoppingCart", order);
        }
        public PartialViewResult RemoveFromCart(int id)
        {
            var order = (Models.Order)Session["Cart"];
            foreach (var item in order.Orders)
            {
                if (item.Product.ID == id)
                {
                    order.Orders.Remove(item);
                    break;
                }
            }
            return PartialView("_ShoppingCart", order);
        }
        [Authorize]
        public ViewResult AcceptCart()
        {
            var order = (Models.Order)Session["Cart"];
            if (DataAccess.OrderDBO.AddOrder(order, WebSecurity.CurrentUserId))
            {
                ViewBag.Status = "Đặt hàng thành công";
            }
            else
            {
                ViewBag.Status = "Đặt hàng thất bại";
            }
            return View();
        }

    }
}
