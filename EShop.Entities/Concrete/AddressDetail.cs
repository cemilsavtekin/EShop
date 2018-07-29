using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class AddressDetail:IEntity
    {
        public int ID { get; set; }
        public string AdresDetay { get; set; }

        public County County { get; set; }
    }
}
