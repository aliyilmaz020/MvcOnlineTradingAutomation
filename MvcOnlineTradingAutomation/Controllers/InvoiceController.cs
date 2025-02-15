﻿using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
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
        [HttpGet]
        public ActionResult CreateInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInvoice(Invoice invoice)
        {
            invoice.InvoiceStatus = true;
            db.Invoices.Add(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetInvoice(int id)
        {
            var invoice = db.Invoices.Find(id);
            return View(invoice);
        }
        public ActionResult EditInvoice(Invoice i)
        {
            var value = db.Invoices.Find(i.InvoiceId);
            value.InvoiceSequenceNum = i.InvoiceSequenceNum;
            value.InvoiceSerial = i.InvoiceSerial;
            value.InvoiceDate = i.InvoiceDate;
            value.InvoiceTime = i.InvoiceTime;
            value.InvoiceTaxOffice = i.InvoiceTaxOffice;
            value.InvoiceDelivery = i.InvoiceDelivery;
            value.InvoiceRecevier = i.InvoiceRecevier;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}