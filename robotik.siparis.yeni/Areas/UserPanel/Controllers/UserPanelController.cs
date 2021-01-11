using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity2;

namespace robotik.siparis.yeni.Areas.UserPanel.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel/UserPanel
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderListAccountant()
        {
            return View();
        }

        public ActionResult ProfileView()
        {

            return View();
        }
        [HttpPost]
        public JsonResult UserAdd(string FirstName, string LastName, string Email, string Password, string Atelieer, string Address)
        {
            int Atelier = Convert.ToInt32(Atelieer);

            User user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                AtelierID = Atelier,
                Address = Address,
                CreatedOn = DateTime.Now

            };
            db.Users.Add(user);

            db.SaveChanges();
            Basket basket = new Basket()
            {
                Code = user.ID
            };
            db.Baskets.Add(basket);
            db.SaveChanges();
            db.Users.Where(x => x.ID == user.ID).FirstOrDefault().BasketID = basket.ID;
            db.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult UserUpdate(string FirstName, string LastName, string Email)
        {
            User currentUser = Session["currentUser"] as User;
            User user = db.Users.Where(x => x.ID == currentUser.ID).FirstOrDefault();
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;

            Session["currentUser"] = user;

            db.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}