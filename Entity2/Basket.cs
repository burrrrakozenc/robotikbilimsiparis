using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class Basket:BaseEntity
    {
        public int Code { get; set; }
        //public int? UserID { get; set; }
    }
}
