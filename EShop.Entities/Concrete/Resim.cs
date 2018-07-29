using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class Resim:IEntity
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public int ImageType { get; set; }

        public Product Product { get; set; }
    }
}
