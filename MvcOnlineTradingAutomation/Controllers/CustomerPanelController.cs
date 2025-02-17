﻿using MvcOnlineTradingAutomation.Context;
using System.Linq;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class CustomerPanelController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        [Authorize]
        // GET: CustomerPanel
        public ActionResult Index()
        {
            string mail = (string)Session["CustomerMail"];
            ViewBag.Mail = mail;

            var values = db.Customers.FirstOrDefault(x=>x.CustomerMail == mail);
            return View(values);
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Orders()
        {
            string mail = (string)Session["CustomerMail"];
            var id = db.Customers.Where(x=>x.CustomerMail==mail).Select(x=>x.CustomerId).FirstOrDefault();
            var values = db.SalesOperations.Where(x=>x.CustomerId==id).ToList();
            return View(values);
        }
    }
}