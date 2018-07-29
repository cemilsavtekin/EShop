using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class Order:IEntity
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string TeslimAlan { get; set; }
        public bool OrderState { get; set; }


        public AddressDetail AddressDetail { get; set; }
        [ForeignKey("ID")]
        public int AddressID { get; set; }

        public Customer Customer { get; set; }
        [ForeignKey("ID")]
        public int CustomerID { get; set; }

        public Cart Cart { get; set; }
        [ForeignKey("ID")]
        public int CartID { get; set; }
    }
}
