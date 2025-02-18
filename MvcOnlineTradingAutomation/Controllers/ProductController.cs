using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
       Mvc5Context db = new Mvc5Context();
        public ActionResult Index(string p,int page=1)
        {
            var products = db.Products.Where(x=>x.ProductStatus==true).ToList();
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(y=>y.ProductName.ToLower().Contains(p.ToLower()) || y.ProductBrand.ToLower().Contains(p.ToLower())).ToList();
            }
            return View(products.ToPagedList(page, 10));
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> value1 = db.Categories.Select(x=>new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.Value1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            p.ProductStatus = true;
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveProduct(int id)
        {
            var product = db.Products.Find(id);
            product.ProductStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var categories = db.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.Categories = categories;
            var product = db.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product p) 
        {
            var product = db.Products.Find(p.ProductId);
            product.ProductName = p.ProductName;
            product.ProductSalePrice = p.ProductSalePrice;
            product.ProductStatus = p.ProductStatus;
            product.ProductImage = p.ProductImage;
            product.CategoryId = p.CategoryId;
            product.ProductBrand = p.ProductBrand;
            product.ProductCashPrice = p.ProductCashPrice;
            product.ProductStock = p.ProductStock;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var values = db.Products.ToList();
            return View(values);
        }
    }
}