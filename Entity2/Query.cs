using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class Query
    {
        private static DatabaseContext db = new DatabaseContext();
        public static List<Product> ProductList()
        {
            List<Product> list = db.Products.AsNoTracking().ToList();
            return list;
        }
        public static List<User> UserList()
        {
            List<User> users = db.Users.AsNoTracking().ToList();
            return users;
        }
        public static List<Basket> BasketList()
        {
            List<Basket> baskets = db.Baskets.AsNoTracking().ToList();
            return baskets;
        }
        public static List<Order> OrderList()
        {
            List<Order> orders = db.Orders.AsNoTracking().ToList();
            return orders;
        }
        public static List<BasketProduct> BasketProductList()
        {
            List<BasketProduct> basketProducts = db.BasketProducts.AsNoTracking().ToList();
            return basketProducts;
        }
        public static List<Category> CategoryList()
        {
            List<Category> categories = db.Categories.AsNoTracking().ToList();
            return categories;
        }
        public static List<Atelier> AtelierList()
        {
            List<Atelier> ateliers = db.Ateliers.AsNoTracking().ToList();
            return ateliers;
        }
        public static List<Address> AddressList()
        {
            List<Address> addresses = db.Addresses.AsNoTracking().ToList();
            return addresses;
        }
        public static List<Role> RoleList()
        {
            List<Role> roles = db.Roles.AsNoTracking().ToList();
            return roles;
        }
    }
}
