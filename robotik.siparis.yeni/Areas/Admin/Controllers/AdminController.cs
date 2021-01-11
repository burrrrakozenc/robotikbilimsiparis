using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entity2;
using robotik.siparis.yeni.Models;

namespace robotik.siparis.yeni.Areas.Admin.Controllers
{
    //[CustomAuthenticationFilter]
    
    public class AdminController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderListAccountant()
        {
            List<Order> orders = db.Orders.Where(x => x.OrderStatus == false).ToList();
            foreach (var i in orders)
            {
                if (i.PaymentStatus == true && i.DeliveryStatus == true)
                {
                    i.OrderStatus = true;
                    db.SaveChanges();
                }
            }
            return View();
        }
        
        public ActionResult OrderListShipment()
        {
            return View();
        }

        public ActionResult OrderListStorage()
        {
            return View();
        }
    }
}