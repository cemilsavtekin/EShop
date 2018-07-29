using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class City:IEntity
    {
        public int ID { get; set; }
        public string CityName { get; set; }
    }
}
