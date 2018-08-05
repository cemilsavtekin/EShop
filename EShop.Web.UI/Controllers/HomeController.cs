using EShop.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EShop.Web.UI.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult ProductDetails(/*int id*/)
        {
            return View();
        }

        public ActionResult SiparisTamamla()
        {
            return View();
        }
        public ActionResult Sepet()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(MailModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var body = "<p>Email from: {0} ({1}) </p> <p>{2}</p>";

                    var message = new MailMessage();
                    message.To.Add(new MailAddress("smart405@gocen.org"));
                    message.From = new MailAddress(obj.FromEmail);
                    message.Subject = obj.EmailSubject;
                    message.Body = string.Format(body, obj.Name, obj.FromEmail, obj.EmailBody);
                    message.IsBodyHtml = true;

                    using (var smtp=new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName="smart405@gocen.org",
                            Password="Smart405"
                        };

                        smtp.Credentials = credential;
                        smtp.Host = "mail.gocen.org";
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //smtp.EnableSsl = true;
                    }

                }
            }
            catch (Exception)
            {
                RedirectToAction("ErrorPage");
            }
            return RedirectToAction("contact");
        }

        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}