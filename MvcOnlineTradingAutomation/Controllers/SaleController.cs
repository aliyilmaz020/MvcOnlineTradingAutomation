using MvcOnlineTradingAutomation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradingAutomation.Models.Entities;

namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: Sale
        public ActionResult Index()
        {
            var sales = db.SalesOperations.ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult CreateSale()
        {
            List<SelectListItem> product = db.Products.Where(x => x.ProductStatus == true).Select(x => new SelectListItem
            {
                Value = x.ProductId.ToString(),
                Text = x.ProductName + "/" + x.ProductSalePrice.ToString() +" ₺" 
            }).ToList();
            ViewBag.Product = product;
            List<SelectListItem> customer = db.Customers.Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Value = x.CustomerId.ToString(),
                Text = x.CustomerName + " " + x.CustomerSurname
            }).ToList();
            ViewBag.Customer = customer;
            List<SelectListItem> employee = db.Employees.Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Value = x.EmployeeId.ToString(),
                Text = x.EmployeeName + " " + x.EmployeeSurname
            }).ToList();
            ViewBag.Employee = employee;
            return View();
        }
        [HttpPost]
        public ActionResult CreateSale(SaleOperation sale)
        {
            int id = sale.ProductId;
            sale.Price = db.Products.Where(x => x.ProductStatus == true && x.ProductId == id).Select(x => x.ProductSalePrice).FirstOrDefault();
            sale.Total = sale.Price * sale.Quantity;
            sale.Date = DateTime.Now;
            db.SalesOperations.Add(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSale(int id)
        {
            List<SelectListItem> product = db.Products.Where(x => x.ProductStatus == true).Select(x => new SelectListItem
            {
                Value = x.ProductId.ToString(),
                Text = x.ProductName
            }).ToList();
            ViewBag.Product = product;
            List<SelectListItem> customer = db.Customers.Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Value = x.CustomerId.ToString(),
                Text = x.CustomerName + " " + x.CustomerSurname
            }).ToList();
            ViewBag.Customer = customer;
            List<SelectListItem> employee = db.Employees.Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Value = x.EmployeeId.ToString(),
                Text = x.EmployeeName + " " + x.EmployeeSurname
            }).ToList();
            ViewBag.Employee = employee;
            var sale = db.SalesOperations.Find(id);
            return View(sale);
        }
        public ActionResult EditSale(SaleOperation sale)
        {
            var value = db.SalesOperations.Find(sale.SaleOperationId);
            value.CustomerId = sale.CustomerId;
            value.ProductId = sale.ProductId;
            value.EmployeeId = sale.EmployeeId;
            value.Quantity = sale.Quantity;
            value.Price = sale.Price;
            value.Total = sale.Quantity * sale.Price;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailSale(int id)
        {
            var values = db.SalesOperations.Where(x => x.SaleOperationId == id).ToList();
            return View(values);
        }
    }
}