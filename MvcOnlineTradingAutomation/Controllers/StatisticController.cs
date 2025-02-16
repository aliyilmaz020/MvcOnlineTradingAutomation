using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class StatisticController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: Statistic
        public ActionResult Index()
        {
            //Toplam Müşteri Sayısı
            ViewBag.d1 = db.Customers.Where(x => x.Status == true).Count().ToString();
            //Ürün Sayısı
            ViewBag.d2 = db.Products.Where(x => x.ProductStatus == true).Count().ToString();
            //Personel Sayısı
            ViewBag.d3 = db.Employees.Where(x => x.Status == true).Count().ToString();
            //Kategori Sayısı
            ViewBag.d4 = db.Categories.Count().ToString();
            //Toplam Stok
            ViewBag.d5 = db.Products.Where(x => x.ProductStatus == true).Sum(x => x.ProductStock).ToString();
            //Marka Sayısı
            ViewBag.d6 = db.Products.Where(x => x.ProductStatus == true).Select(x => x.ProductBrand).Distinct().Count().ToString();
            //Kritik Seviye
            ViewBag.d7 = db.Products.Where(x => x.ProductStatus == true && x.ProductStock < 20).Count().ToString();
            //En Pahalı Ürün
            ViewBag.d8 = db.Products.Where(x => x.ProductStatus == true).OrderByDescending(x => x.ProductSalePrice).Select(x => x.ProductName).FirstOrDefault();
            //En Ucuz Ürün
            ViewBag.d9 = db.Products.Where(x => x.ProductStatus == true).OrderBy(x => x.ProductSalePrice).Select(x => x.ProductName).FirstOrDefault();
            //En Çok Marka
            ViewBag.d12 = db.Products.Where(x => x.ProductStatus == true).GroupBy(x => x.ProductBrand).OrderByDescending(x => x.Count()).Select(y => y.Key).FirstOrDefault();
            //Buzdolabı Sayısı
            ViewBag.d10 = db.Products.Where(x => x.ProductStatus == true && x.ProductName.Contains("Buzdolabı")).Count().ToString();
            //Bilgisayar Sayısı
            ViewBag.d11 = db.Products.Where(x => x.ProductStatus == true && x.Category.CategoryName == "Bilgisayar").Count().ToString();
            //Kasadaki Tutar
            ViewBag.d14 = db.SalesOperations.Sum(x => x.Total).ToString() + " ₺";
            //Bugünkü Satışlar
            DateTime t = DateTime.Today;
            ViewBag.d15 = db.SalesOperations.Count(x => x.Date.Year == t.Year && x.Date.Month == t.Month && x.Date.Day == t.Day).ToString();
            //En Çok Satan
            ViewBag.d13 = db.SalesOperations.GroupBy(x => x.Product.ProductName).OrderByDescending(x => x.Count()).Select(y => y.Key).FirstOrDefault();
            //Bugünkü Kasa
            if (db.SalesOperations.Where(x => x.Date.Year == t.Year && x.Date.Month == t.Month && x.Date.Day == t.Day).Count() == 0)
            {
                ViewBag.d16 = "0";
            }
            else
            {
                ViewBag.d16 = db.SalesOperations.Where(x => x.Date.Year == t.Year && x.Date.Month == t.Month && x.Date.Day == t.Day).Sum(x => x.Total).ToString();
            }
            return View();
        }
        public ActionResult SimpleTables()
        {
            var query = db.Customers.Where(x=>x.Status==true).GroupBy(x => x.CustomerCity).Select(y => new ClassGroup
            {
                City = y.Key,
                Count = y.Count()
            }).OrderByDescending(x=>x.Count).ToList();
            return View(query);
        }
        public PartialViewResult Category()
        {
            var total = db.Products.Where(x => x.ProductStatus == true).GroupBy(x => x.Category.CategoryName).Sum(x => x.Count());
            ViewBag.Total = total;
            List<SelectListItem> values = db.Products.Where(x => x.ProductStatus == true).GroupBy(x => x.Category.CategoryName).Select(x => new SelectListItem
            {
              Text = x.Key,
              Value = x.Count().ToString()
            }).OrderByDescending(x=>x.Value).ToList();
            return PartialView(values);
        }
        public PartialViewResult Department()
        {
            var total = db.Employees.Where(x => x.Status == true).GroupBy(x => x.Department.DepartmentName).Sum(x=>x.Count());
            ViewBag.Total = total;
            List<SelectListItem> values = db.Employees.Where(x => x.Status == true).GroupBy(x => x.Department.DepartmentName).Select(x => new SelectListItem
            {
                Text = x.Key,
                Value = x.Count().ToString()
            }).OrderByDescending(x => x.Value).ToList();
            return PartialView(values);
        }
        public PartialViewResult Customer()
        {
            var customers = db.Customers.Where(x => x.Status == true).ToList();
            return PartialView(customers);
        }
        public PartialViewResult Product()
        {
            var products = db.Products.Where(x => x.ProductStatus == true).ToList();
            return PartialView(products);
        }
        public PartialViewResult Brand()
        {
            var total = db.Products.Where(x => x.ProductStatus == true).GroupBy(x => x.ProductBrand).Sum(x=>x.Count());
            ViewBag.Total = total;
            List<SelectListItem> brands = db.Products.Where(x => x.ProductStatus == true).GroupBy(x => x.ProductBrand).Select(x => new SelectListItem
            {
                Text = x.Key,
                Value = x.Count().ToString()
            }).OrderByDescending(x=>x.Value).Take(6).ToList();
            return PartialView(brands);
        }
    }
}