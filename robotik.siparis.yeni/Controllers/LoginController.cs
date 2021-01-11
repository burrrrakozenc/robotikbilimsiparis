using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace robotik.siparis.yeni.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private DatabaseContext db = new DatabaseContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var currentUser = db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            Session["currentUser"] = currentUser;
            if (currentUser != null)
            {
                FormsAuthentication.SetAuthCookie(currentUser.Email, false);
                return RedirectToAction("ProductList", "Product");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}