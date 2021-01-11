using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity2;

namespace robotik.siparis.yeni.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderSend(string BasketID)
        {
            
            int basketID = Convert.ToInt32(BasketID);

            if (db.BasketProducts.Where(x => x.BasketID == basketID).Where(x => x.OrderID == null).Count() == 0)
            { 
                
            } else
            {
                User u = Session["currentUser"] as User;
                User us = db.Users.AsNoTracking().Where(x => x.ID == u.ID).SingleOrDefault();

                List<BasketProduct> basketProduct = db.BasketProducts.Where(x => x.BasketID == basketID).Where(x => x.OrderID == null).ToList();

                double totalPrice = basketProduct.Where(x => x.BasketID == us.BasketID).Sum(s => s.SubTotal);

                Order order = new Order()
                {
                    BasketID = basketID,
                    BasketProduct = basketProduct,
                    TotalPrice = totalPrice,
                    CreatedOn = DateTime.Now,
                    UserSubmit = true
                };

                foreach (var i in basketProduct)
                {
                    i.OrderID = order.ID;
                }

                db.Orders.Add(order);
                db.SaveChanges();
            }


            return View(); //Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BasketProductDelete(string BasketID, string ProductID)
        {
            int basketid = Convert.ToInt32(BasketID);
            int productid = Convert.ToInt32(ProductID);

            BasketProduct basketProduct = db.BasketProducts.Where(x => x.BasketID == basketid).Where(x => x.ProductID == productid).Where(x=> x.OrderID == null).FirstOrDefault();

            db.BasketProducts.Remove(basketProduct);
            db.SaveChanges();


            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderGiven()
        {
            return View();
        }
        public ActionResult SendOrder()
        {
            return View();
        }
    }
}