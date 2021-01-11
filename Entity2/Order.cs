using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity2
{
    public class Order:BaseEntity
    {
        public Basket Basket { get; set; }
        public int BasketID { get; set; }
        public IEnumerable<BasketProduct> BasketProduct { get; set; }
        public double TotalPrice { get; set; }
        public string ShipmentNo { get; set; }
        //public string ShipmentDetails { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public bool UserSubmit { get; set; }
        public bool AccountingStatus { get; set; }
        public bool StoreStatus { get; set; }
        public bool ShipmentStatus { get; set; }
        public bool OrderStatus { get; set; }
        public bool PaymentStatus { get; set; }
        public bool DeliveryStatus { get; set; }






        //siparisten sonraki tarih true
        //eger uzak tarihse false oldu mesaji geri bildirim

        //muhasebe kisminda askiya alma yetkisi var


        //tahmini teslim tarihi ilk onayda
        //siparis hazirlaniyor durumdayken iptal edilemez
        //tahmini tarihi girildiginde sube ye mesaj gidecek
        //melek hanim onay iste butonu

    }
}
