using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class ChartController : Controller
    {
        // GET: Graphic
        Mvc5Context db = new Mvc5Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var chart = new Chart(width: 600, height: 600);
            chart.AddTitle("Kategori-Ürün Stok Sayısı")
                .AddLegend("Stok")
                .AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Küçük Ev Aleti", "Mobilya" },
                yValues: new[] { 200, 100, 345 });
            return File(chart.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var results = db.Products.Where(x => x.ProductStatus == true).ToList();
            results.ForEach(x => xvalue.Add(x.ProductName));
            results.ForEach(x => yvalue.Add(x.ProductStock));
            var charts = new Chart(width: 1000, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(charts.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {

            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> ProductList()
        {
            List<Class1> cls = new List<Class1>();
            cls.Add(new Class1()
            {
                Name = "PC",
                Stock = 120
            });
            cls.Add(new Class1()
            {
                Name = "Mobilya",
                Stock = 70
            });
            cls.Add(new Class1()
            {
                Name = "Beyaz Eşya",
                Stock = 150
            });
            cls.Add(new Class1()
            {
                Name = "Küçük Ev Aletleri",
                Stock = 40
            });
            cls.Add(new Class1()
            {
                Name = "Telefon",
                Stock = 47
            });
            return cls;
        }
    }
}