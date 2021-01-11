using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity2;

namespace robotik.siparis.yeni.Controllers
{
    public class AtelierController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AtelierAdd(string Name)
        {
            User currentUser = Session["currentUser"] as User;
            Atelier atelier = new Atelier()
            {
                Name = Name
            };
            db.Ateliers.Add(atelier);
            db.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}