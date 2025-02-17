using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
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
    }
}