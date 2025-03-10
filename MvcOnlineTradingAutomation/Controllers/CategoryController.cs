﻿using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTradingAutomation.Attributes;
namespace MvcOnlineTradingAutomation.Controllers
{
    [CustomAuthorize(Roles ="A,B")]
    public class CategoryController : Controller
    {
        Mvc5Context db = new Mvc5Context();

        // GET: Category
        [HttpGet]
        public ActionResult Index(int page=1)
        {
            var categories = db.Categories.ToList().ToPagedList(page,5);
            return View(categories);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveCategory(int id)
        {
            var value = db.Categories.Find(id);
            db.Categories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            var value = db.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Demo()
        {
            Class3 cs = new Class3();
            cs.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
            cs.Products = new SelectList(db.Products, "ProductId", "ProductName");
            return View(cs);
        }
        public JsonResult GetProduct(int p)
        {
            var products = db.Products.Where(x=>x.ProductStatus==true).Join(db.Categories, x => x.CategoryId, y => y.CategoryId, (x, y) => new { x, y }).Where(d1=>d1.x.CategoryId == p)
                .Select(z => new
                {
                    Text = z.x.ProductName,
                    Value = z.x.ProductId.ToString()
                }).ToList(); 
            return Json(products,JsonRequestBehavior.AllowGet);
        }
    }
}