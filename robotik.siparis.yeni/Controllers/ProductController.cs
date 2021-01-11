using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace robotik.siparis.yeni.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Product
        public ActionResult Index()
        {
            User u = Session["currentUser"] as User;
            List<SelectListItem> Category = new List<SelectListItem>();
            
            foreach (var i in db.Categories.ToList())
            {
                Category.Add(new SelectListItem { Text = i.CategoryName, Value = i.ID.ToString() });
            }
            ViewBag.Category = Category;

            List<SelectListItem> Products = new List<SelectListItem>();
            foreach (var i in db.Products.ToList())
            {
                Products.Add(new SelectListItem { Text = i.ProductName, Value = i.ID.ToString() });
            }
            ViewBag.Products = Products;
            return View();
        }

        [HttpPost]
        public JsonResult ProductAdd(string ProductName, string ProductPrice, string ProductStock, string Category)
        {
            Product product = new Product()
            {
                ProductName = ProductName,
                ProductPrice = Convert.ToInt32(ProductPrice),
                ProductStock = Convert.ToInt32(ProductStock),
                CategoryID = Convert.ToInt32(Category),
                CreatedOn = DateTime.Now
            };

            db.Products.Add(product);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }

        public void AddToBasket(string id, string qntty) {
            int ID = Convert.ToInt32(id);
            int Qntty = Convert.ToInt32(qntty);
            User u = Session["currentUser"] as User;
            User us = db.Users.AsNoTracking().Where(x => x.ID == u.ID).SingleOrDefault();

            Product product = db.Products.Where(x => x.ID == ID).FirstOrDefault();

            List<BasketProduct> basketProducts = db.BasketProducts.Where(x => x.OrderID == null).Where(a => a.BasketID == us.BasketID).ToList();

            BasketProduct bp;

            if (basketProducts.Exists(e => e.ProductID == ID))
            {
                bp = basketProducts.Where(x => x.ProductID == ID).FirstOrDefault();

                bp.Quantity += Qntty;
                bp.SubTotal += Qntty * product.ProductPrice;

            } else
            {
                bp = new BasketProduct()
                {
                    ProductID = product.ID,
                    Quantity = Qntty,
                    SubTotal = Qntty * product.ProductPrice,
                    BasketID = us.BasketID,
                    CreatedOn = DateTime.Now
                };
                db.BasketProducts.Add(bp);
            }
            db.SaveChanges();
            
        }

        public JsonResult ProductCategory (string Product2, string Category2)
        {
            int prdID = Convert.ToInt32(Product2);
            int ctgryID = Convert.ToInt32(Category2);
            Product product = db.Products.Where(x => x.ID == prdID).FirstOrDefault();

            product.CategoryID = ctgryID;
            db.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ProductList(string searching)
        {
            return Json(db.Products.Where(x => x.ProductName.Contains(searching) || searching == null).ToList(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult pList () 
        {
            return View();
        }




    }
}