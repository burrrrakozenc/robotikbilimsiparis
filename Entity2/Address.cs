using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class Address
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int AtelierID { get; set; }
        public virtual Atelier Atelier { get; set; }
        public string Phone { get; set; }
    }
}
