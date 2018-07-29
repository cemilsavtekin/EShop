using EShop.Entities.Concrete.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class Cart:BaseEntity
    {
        public int CartID { get; set; }

        public Customer Customer { get; set; }
        [ForeignKey("ID")]
        public int CustomerID { get; set; }
    }
}
