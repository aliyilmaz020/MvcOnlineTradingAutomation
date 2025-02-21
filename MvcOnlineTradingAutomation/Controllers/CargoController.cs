using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
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
        [HttpGet]
        public ActionResult QrCode(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return Json(new { error = "ID boş olamaz." }, JsonRequestBehavior.AllowGet);

                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(10))
                    {
                        qrCodeImage.Save(ms, ImageFormat.Png);
                        string base64Image = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                        return Json(new { qrCode = base64Image }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}