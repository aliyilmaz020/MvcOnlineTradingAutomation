using System;
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
                yValues: new[] { 200, 100, 345 }).Write();
            return File(chart.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}