using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EShop.Entities.Abstract;

namespace EShop.Entities.Concrete.Account
{
  
    public class User:IEntity
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        public Role Role { get; set; }
        
    }
}
