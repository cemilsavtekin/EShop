using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? UstKategoriID { get; set; }

        public ICollection<Product> UrunResimleri { get; set; }

        public int? BrandID { get; set; }
        [ForeignKey("BrandID")]
        public Brand MarkaResmi { get; set; }
    }
}
