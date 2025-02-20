using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
    public class CargoController : Controller
    {
        // GET: Cargo
        Mvc5Context db = new Mvc5Context();

        public ActionResult Index(string p)
        {
            Random rnd = new Random();
            string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
            int k1, k2, k3;
            k1 = rnd.Next(0, chars.Length);
            k2 = rnd.Next(0, chars.Length);
            k3 = rnd.Next(0, chars.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 199);
            s3 = rnd.Next(10, 99);
            string code = s1.ToString() + chars[k1] + s2.ToString() + chars[k2] + s3.ToString() + chars[k3];
            ViewBag.Code = code;
            var cargos = db.Cargos.Select(x => x);
            if (!string.IsNullOrEmpty(p))
            {
                cargos = cargos.Where(x => x.TrackingCode.Contains(p));
            }
            return View(cargos.ToList());
        }
        [HttpGet]
        public ActionResult CreateCargo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCargo(Cargo cargo)
        {
            db.Cargos.Add(cargo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CargoTracking(string id)
        {
            var cargoTracking = db.CargoTrackings.Where(x=>x.TrackingCode == id).ToList();
            return View(cargoTracking);
        }
    }
}