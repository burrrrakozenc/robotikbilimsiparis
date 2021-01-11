using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class BaseEntity
    {
        public int ID { get; set; }
        //[Column(TypeName = "Date")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedOn { get; set; }

     
        

    }
}
