using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingEcommerceApp.Controllers
{
    public class GuidDemoController : Controller
    {
        // Route: /GuidDemo/{id}
        public IActionResult Details(string id)
        {
            ViewBag.GuidValue = id;
            return View();
        }
    }
}
