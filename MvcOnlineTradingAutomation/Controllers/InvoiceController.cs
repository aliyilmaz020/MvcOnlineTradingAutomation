using MvcOnlineTradingAutomation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: Invoice
        public ActionResult Index()
        {
            var invoices = db.Invoices.ToList();
            return View(invoices);
        }
    }
}