using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace robotik.siparis.yeni.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private DatabaseContext db = new DatabaseContext();
        
        public ActionResult Index()
        {
            return View();
        }
    }
}