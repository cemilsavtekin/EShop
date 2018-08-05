using EShop.Entities.Concrete.Account;
using EShop.Entities.Concrete.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete
{
    public class Customer:BaseEntity
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }


        public int? AddressDetailID { get; set; }
        [ForeignKey("AddressDetailID")]
        public AddressDetail AddressDetail { get; set; }

    }
}
