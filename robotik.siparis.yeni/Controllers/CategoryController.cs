using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entity2;
using robotik.siparis.yeni.Models;

namespace robotik.siparis.yeni.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            foreach (var i in db.Categories.ToList())
            {
                categories.Add(new SelectListItem { Text = i.CategoryName, Value = i.ID.ToString() });

            }
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public JsonResult CategoryAdd(string CategoryName, string Categories)
        {
            if (Categories == "")
            {
                Categories = "1";
            }
            int id = Convert.ToInt32(Categories);
            Category category = new Category()
            {
                CategoryName = CategoryName,
                ParentID = id
            };
            List<Category> categories = db.Categories.Where(x => x.ID == id).FirstOrDefault().SubCategories; /*= category.CategoryName;*/
            Category category1 = db.Categories.Where(x => x.ID == id).FirstOrDefault();
            categories.Add(category1);
            

            db.Categories.Add(category);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult CategoryList()
        {            
            return View();
        }

    }
}