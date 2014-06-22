using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
namespace SieuThiMVC.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        //
        // GET: /Manage/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductsManagement()
        {
            return View();
        }
        public ActionResult AccountManagement()
        {
            return View();
        }
        public ActionResult CommentManagement()
        {
            return View();
        }
        public ActionResult SProduct()
        {
            ViewBag.Items = DataAccess.ProductsDBO.GetSortsOfProduct();
            return View();
        }
        [HttpPost]
        public ActionResult SProduct(Models.SortOfProductModel model)
        {
            ViewBag.Items = DataAccess.ProductsDBO.GetSortsOfProduct();
            if (ModelState.IsValid)
            {
                DataAccess.ProductsDBO.AddSortOfProduct(model.SProduct);
            }
            return RedirectToAction("SProduct");
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Models.ProductModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/ProductImages/" + file.FileName));
                    model.ImgLink = file.FileName;
                    DataAccess.ProductsDBO.AddProduct(model);
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }

        public ActionResult SelectCategory(Models.SortOfProduct product)
        {
            List<Models.Product> products = null;
            products = DataAccess.ProductsDBO.GetProductsByCategory(product.ID);
            return PartialView("_productsMagagePartial", new Models.ListProduct { SelectedID = product.ID, MyList = products });
        }
        
        
        [HttpPost]
        [Authorize]
        public PartialViewResult DeleteAccount(string name)
        {
            if (name != WebSecurity.CurrentUserName)
            {
                DataAccess.UserProfileDBO.DeleteUserAccount(name);
                ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(name); 
            }
            return PartialView("_AccountListPartial");
        }

        [HttpPost]
        [Authorize]
        public PartialViewResult DeleteProduct(string name)
        {
            DataAccess.ProductsDBO.DeleteProduct(name);
            return PartialView("_productsMagagePartial");
        }
    }
}
