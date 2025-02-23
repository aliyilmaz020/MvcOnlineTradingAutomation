using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using static QRCoder.PayloadGenerator;

namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
    public class CustomerPanelController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: CustomerPanel
        public ActionResult Index()
        {
            string mail = (string)Session["CustomerMail"];
            ViewBag.Mail = mail;
            var values = db.Customers.FirstOrDefault(x=>x.CustomerMail == mail);
            var customerId = db.Customers.Where(x=>x.CustomerMail == mail).Select(x=>x.CustomerId).FirstOrDefault();
            ViewBag.CustomerId = customerId;
            var sales = db.SalesOperations.Where(x=>x.CustomerId == customerId).Count();
            ViewBag.TotalSale = sales;
            if (db.SalesOperations.Where(x => x.CustomerId == customerId).Count() > 0)
            {
                var totalPrice = db.SalesOperations.Where(x => x.CustomerId == customerId).Sum(x => x.Total);
                ViewBag.TotalPrice = totalPrice;
                var quantitySale = db.SalesOperations.Where(x => x.CustomerId == customerId).Sum(x => x.Quantity);
                ViewBag.TotalQuantity = quantitySale;
            }
            else
            {
                ViewBag.TotalPrice = 0;
                ViewBag.TotalQuantity = 0;
            }
            return View(values);
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Orders()
        {
            string mail = (string)Session["CustomerMail"];
            var id = db.Customers.Where(x=>x.CustomerMail==mail).Select(x=>x.CustomerId).FirstOrDefault();
            var values = db.SalesOperations.Where(x=>x.CustomerId==id).ToList();
            return View(values);
        }
        public ActionResult Messages()
        {
            string mail = (string)Session["CustomerMail"];
            var messages = db.Messages.Where(x=>x.Receiver == mail).OrderByDescending(x=>x.Date).ToList();
            var receivedMessageCount = db.Messages.Count(x=>x.Receiver==mail).ToString();
            var sentMessageCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sentMessageCount;
            ViewBag.d1 = receivedMessageCount;
            return View(messages);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            string mail = (string)Session["CustomerMail"];
            var sentMessageCount = db.Messages.Count(x => x.Sender == mail).ToString();
            var receivedMessageCount = db.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = receivedMessageCount;
            ViewBag.d2 = sentMessageCount;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string mail = (string)Session["CustomerMail"];
            message.Date = DateTime.Now;
            message.Sender = mail;
            db.Messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Messages","CustomerPanel");
        }
        public ActionResult SentMessages()
        {
            string mail = (string)Session["CustomerMail"];
            var messages = db.Messages.Where(x => x.Sender == mail).ToList();
            var sentMessageCount = db.Messages.Count(x => x.Sender == mail).ToString();
            var receivedMessageCount = db.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = receivedMessageCount;
            ViewBag.d2 = sentMessageCount;
            return View(messages);
        }
        public ActionResult SentMessageDetail(int id)
        {
            string mail = (string)Session["CustomerMail"];
            var sentMessageCount = db.Messages.Count(x => x.Sender == mail).ToString();
            var receivedMessageCount = db.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = receivedMessageCount;
            ViewBag.d2 = sentMessageCount;
            var message = db.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            return View(message);
        }
        public ActionResult DetailMessage(int id)
        {
            string mail = (string)Session["CustomerMail"];
            var receivedMessageCount = db.Messages.Count(x => x.Receiver == mail).ToString();
            var sentMessageCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sentMessageCount;
            ViewBag.d1 = receivedMessageCount;
            var message = db.Messages.Where(x=>x.MessageId == id).FirstOrDefault();
            return View(message);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}