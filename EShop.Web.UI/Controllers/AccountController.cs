using EShop.Business.Manage;
using EShop.Entities.Concrete.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EShop.Web.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var kul = DBManager<User>.Get(x => x.UserName == user.UserName && x.Password == user.Password);

            if (kul!=null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ValidationMessage"] = "Kullanıcı adı veya şifre hatalı";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var kul = DBManager<User>.Get(x => x.UserName == user.UserName || x.Email == user.Email);

            if (kul!=null)
            {
                ModelState.AddModelError("", "Bu email ya da kullanıcı adı sistemde Kayıtlı");

                //ModelState.Clear();

                return View("Login");
            }
            else
            {
                DBManager<User>.Add(user);

                FormsAuthentication.SetAuthCookie(user.UserName, false);

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}