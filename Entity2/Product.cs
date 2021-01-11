using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductPriceUSD { get; set; }
        public int ProductStock { get; set; }
        public string ProductImage { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public string ProductCode { get; set; }
    }
}
