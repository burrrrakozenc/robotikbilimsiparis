using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }
        public virtual List<Category> SubCategories { get; set; }
    }
}
