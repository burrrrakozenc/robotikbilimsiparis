using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class User: BaseEntity
    {
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? AtelierID { get; set; }
        public Atelier Atelier { get; set; }
        public string Address { get; set; }
        public int? BasketID { get; set; }
        public virtual Basket Basket { get; set; }
        public int? RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
