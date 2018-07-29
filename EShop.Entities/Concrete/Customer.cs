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
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public User User { get; set; }
        [ForeignKey("ID")]
        public int UserID { get; set; }

        public AddressDetail AddressDetail { get; set; }
        [ForeignKey("ID")]
        public int AddressID { get; set; }

    }
}
