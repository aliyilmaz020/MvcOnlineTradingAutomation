using MvcOnlineTradingAutomation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Mvc5Context db = new Mvc5Context();
        public ActionResult Index()
        {
            ViewBag.d1 = db.Employees.Where(x=>x.Status==true).Count().ToString();
            ViewBag.d2 = db.Products.Where(x=>x.ProductStatus==true).Count().ToString();
            ViewBag.d3 = db.Categories.Count().ToString();
            ViewBag.d4 = db.Employees.Where(x=>x.Status==true).Select(x=>x.EmployeeCity).Distinct().Count().ToString();
            return View();
        }
    }
}