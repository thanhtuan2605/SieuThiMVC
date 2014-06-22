using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Authentication;
using System.Web.Mvc;

namespace SieuThiMVC.Permission
{
    public class PermissionsAttribute : ActionFilterAttribute
    {
        public enum Permissions
        {
            View = (1 << 0),
            Manage = (1<<1),
            Admin = (View | Manage)
        }
        private readonly Permissions required;

        public PermissionsAttribute(Permissions required)
        {
            this.required = required;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            List<int> user = null;//var user = null;// filterContext.HttpContext.Session.GetUser();
            if (user == null)
            {
                //send them off to the login page
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = url.Content("~/Home/Login");
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
            else
            {
                //if (!user.HasPermissions(required))
                {
                    throw new AuthenticationException("You do not have the necessary permission to perform this action");
                }
            }
        }
    }
}