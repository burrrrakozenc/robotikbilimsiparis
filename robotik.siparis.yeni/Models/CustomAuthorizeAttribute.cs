using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    private readonly string[] allowedroles;
    public CustomAuthorizeAttribute(params string[] roles)
    {
        this.allowedroles = roles;
    }
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        bool authorize = false;
        var userId = Convert.ToString(httpContext.Session["UserId"]);
        if (!string.IsNullOrEmpty(userId))
            using (var db = new DatabaseContext())
            {
                var userRole = (from u in db.Users
                                join r in db.Roles on u.RoleID equals r.ID
                                where u.ID == Convert.ToInt32(userId)
                                select new
                                {
                                    r.Name
                                }).FirstOrDefault();
                foreach (var role in allowedroles)
                {
                    if (role == userRole.Name) return true;
                }
            }


        return authorize;
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        filterContext.Result = new RedirectToRouteResult(
           new RouteValueDictionary
           {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
           });
    }
}






//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace robotik.siparis.yeni.Models
//{
//    [AttributeUsage(AttributeTargets.Method)]
//    public class CustomAuthorizeAttribute: AuthorizeAttribute
//    {
//        public string ViewName { get; set; }

//        public CustomAuthorizeAttribute()
//        {
//            ViewName = "AuthorizeFailed";
//        }
//        public override void OnAuthorization(AuthorizationContext filterContext)
//        {
//            base.OnAuthorization(filterContext);
//        }

//        void IsUserAuthorize(AuthorizationContext filterContext)
//        {
//            if (filterContext.Result == null)
//                return;
//            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
//            {
//                ViewDataDictionary dic = new ViewDataDictionary();
//                dic.Add("Message", "You dont have privileges for this attribute");
//                var result = new ViewResult() { ViewName = this.ViewName, ViewData = dic };
//                filterContext.Result = result;
//            }
//        }
//    }
//}