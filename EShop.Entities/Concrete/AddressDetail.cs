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
        public int AddressDetailID { get; set; }
        public string AdresDetay { get; set; }

        public int? CountyID { get; set; }
        [ForeignKey("CountyID")]
        public County County { get; set; }
    }
}
