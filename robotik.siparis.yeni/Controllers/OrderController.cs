using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity2;

namespace robotik.siparis.yeni.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            User currentUser = Session["currentUser"] as User;

            foreach (var o in db.Orders.Where(x => x.AccountingStatus == false).ToList())
            {
                
            }
            return View();
        }

        public ActionResult MainStatus()
        {
            return View();
        }

        public ActionResult Status()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Timeline()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Timeline(string a)
        {
            return View();
        }

        [HttpGet]
        public ActionResult superadmin()
        {
            return View();
        }

        [HttpPost]//bunu duzelt be
        public ActionResult superadmin(string he)
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetOrderListAccountant(string OrderID)
        {
            int aID = Convert.ToInt32(OrderID);
            Order order = db.Orders.Where(x => x.ID == aID).FirstOrDefault();
            order.AccountingStatus = true;
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult OrderListStorage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderListStorage(string OrderID)
        {
            int aID = Convert.ToInt32(OrderID);
            Order order = db.Orders.Where(x => x.ID == aID).FirstOrDefault();
            order.StoreStatus = true;
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult OrderListShipment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderListShipment(string OrderID)
        {
            int aID = Convert.ToInt32(OrderID);
            Order order = db.Orders.Where(x => x.ID == aID).FirstOrDefault();
            order.ShipmentStatus = true;
            //order.OrderStatus = true;
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult OrderUserSubmit(string OrderID)
        {
            int id = Convert.ToInt32(OrderID);
            Order order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            order.UserSubmit = true;
            db.SaveChanges();
            return View();
        }

        public JsonResult GetProductList(int id)
        {

            var json = from item in db.BasketProducts.Where(x => x.OrderID == id).ToList() select new { 
                ProductName = item.Product.ProductName,
                Quantity = item.Quantity,
                SubTotal = item.SubTotal
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult OrderDelete(string OrderID)
        {
            int orderid = Convert.ToInt32(OrderID);

            List<BasketProduct> basketProducts = db.BasketProducts.Where(x=>x.OrderID == orderid).ToList();

            List<Order> orders = db.Orders.ToList();

            foreach (var item in basketProducts)
            {
                db.BasketProducts.Remove(item);
                db.SaveChanges();
            }

            Order order = db.Orders.Where(x => x.ID == orderid).FirstOrDefault();

            db.Orders.Remove(order);
            db.SaveChanges();


            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult deneme()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDate(DateTime date, int OrderID)
        {
            Order order = db.Orders.Where(x => x.ID == OrderID).FirstOrDefault();

            TimeSpan ts = date - DateTime.Today;

            int dif = ts.Days;
                
            if (dif > 7)
            {
                order.UserSubmit = false;                
            } else
            {
                order.UserSubmit = true;
            }
            order.ExpectedDeliveryDate = date;
            db.SaveChanges();
            return Json( JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetShipmentNo (int OrderID, string ShipmentNo)
        {
            db.Orders.Where(x => x.ID == OrderID).FirstOrDefault().ShipmentNo = ShipmentNo;
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult OrderAwatingForUser()
        {
            User currentUser = Session["currentUser"] as User;

            List<Order> orders = db.Orders.Where(x => x.OrderStatus == false).ToList();
            foreach (var i in orders)
            {
                if (i.PaymentStatus == true && i.DeliveryStatus == true)
                {
                    i.OrderStatus = true;
                    db.SaveChanges();
                }
            }
            List<Order> ordersUnpaid = db.Orders.Where(e => e.BasketID == currentUser.BasketID).Where(b => b.PaymentStatus == false).ToList();
            int unpaid = ordersUnpaid.Count();
            if (unpaid > 0)
            {
                ViewBag.Para = "Odemenmemis siparisleriniz var.";
            }
            return View();
        }

        [HttpPost]
        public ActionResult PaymentReceived(string OrderID)
        {
            int id = Convert.ToInt32(OrderID);
            Order order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            order.PaymentStatus = true;
            db.SaveChanges();
            return View();
        }
        
        [HttpPost]
        public ActionResult OrderDeliveryReceived(string OrderID)
        {
            int id = Convert.ToInt32(OrderID);
            Order order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            order.DeliveryStatus = true;
            db.SaveChanges();
            return View();
        }
    }

}