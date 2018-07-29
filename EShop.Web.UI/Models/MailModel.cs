using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Web.UI.Models
{
    public class MailModel
    {
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string FromEmail { get; set; }

        public string EmailBody { get; set; }

        public string EmailSubject { get; set; }

    }
}