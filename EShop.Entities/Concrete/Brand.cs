﻿using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class Brand:IEntity
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int Discount { get; set; }

        public int? ResimID { get; set; }
        [ForeignKey("ResimID")]
        public Resim Image{ get; set; }
    }
}
