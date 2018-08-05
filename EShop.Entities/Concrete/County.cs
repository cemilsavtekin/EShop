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
        public int CountyID { get; set; }
        public string CountyName { get; set; }


        public int? CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
    }
}
