using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class CustomerController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.Customers.Where(x => x.Status == true).ToList();
            return View(customers);
        }
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer c)
        {
            c.Status = true;
            db.Customers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            customer.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            return View("GetCustomer",customer);
        }
        public ActionResult EditCustomer(Customer c)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCustomer");
            }
            var customer = db.Customers.Find(c.CustomerId);
            customer.CustomerName = c.CustomerName;
            customer.CustomerSurname = c.CustomerSurname;
            customer.CustomerMail = c.CustomerMail;
            customer.CustomerCity = c.CustomerCity;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}