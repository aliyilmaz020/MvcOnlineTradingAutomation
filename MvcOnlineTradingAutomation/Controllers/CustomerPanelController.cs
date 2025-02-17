using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    public class CustomerPanelController : Controller
    {
        [Authorize]
        // GET: CustomerPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}