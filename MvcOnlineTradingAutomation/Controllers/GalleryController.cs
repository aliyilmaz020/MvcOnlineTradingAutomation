using MvcOnlineTradingAutomation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var values = db.Products.Where(x=>x.ProductStatus==true).ToList();
            return View(values);
        }
    }
}