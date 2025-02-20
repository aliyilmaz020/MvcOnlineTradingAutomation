using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string code)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrCreate = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrCreate.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using(Bitmap bt = qrCode.GetGraphic(10))
                {
                    bt.Save(ms,ImageFormat.Png);
                    ViewBag.QRCode = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}