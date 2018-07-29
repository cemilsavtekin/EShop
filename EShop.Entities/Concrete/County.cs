using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class County: IEntity
    {
        public int ID { get; set; }
        public string CountyName { get; set; }

        public City City { get; set; }
        [ForeignKey("ID")]
        public int CityID { get; set; }
    }
}
