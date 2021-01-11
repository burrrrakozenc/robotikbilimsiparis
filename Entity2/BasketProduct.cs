using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class BasketProduct :BaseEntity
    {
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int? BasketID { get; set; }
        public virtual Basket Basket { get; set; }
        public int? OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
