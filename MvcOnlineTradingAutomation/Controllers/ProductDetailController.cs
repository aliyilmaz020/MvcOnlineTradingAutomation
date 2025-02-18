using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
    public class ProductDetailController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: ProductDetail
        public ActionResult Index()
        {
            Enums enums = new Enums();
            enums.Products = db.Products.Where(x=>x.ProductId==1).ToList();
            enums.Details = db.Details.Where(y=>y.DetailId==1).ToList();
            return View(enums);
        }
    }
}