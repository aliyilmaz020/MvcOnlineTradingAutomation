using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTradingAutomation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Mvc5Context db = new Mvc5Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Customer c)
        {
            c.Status = false;
            db.Customers.Add(c);
            db.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer c)
        {
            string mail = c.CustomerMail;
            string password = c.CustomerPassword;
            bool isLogin = db.Customers.Any(x => x.CustomerMail == mail && x.CustomerPassword == password);
            if (isLogin)
            {
                FormsAuthentication.SetAuthCookie(mail, false);
                Session["CustomerMail"] = mail;
                return RedirectToAction("Index", "CustomerPanel");
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var isLogin = db.Admins.Any(x => x.Username == a.Username && x.Password == a.Password);
            if (isLogin)
            {
                FormsAuthentication.SetAuthCookie(a.Username, false);
                Session["Username"] = a.Username;
                return RedirectToAction("Index", "Category");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}