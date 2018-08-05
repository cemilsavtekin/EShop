using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string TeslimAlan { get; set; }
        public bool OrderState { get; set; }

        public int? AddressDetailID { get; set; }
        [ForeignKey("AddressDetailID")]
        public AddressDetail AddressDetail { get; set; }



        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }


        public int? CartID { get; set; }
        [ForeignKey("CartID")]
        public Cart Cart { get; set; }
    }
}
