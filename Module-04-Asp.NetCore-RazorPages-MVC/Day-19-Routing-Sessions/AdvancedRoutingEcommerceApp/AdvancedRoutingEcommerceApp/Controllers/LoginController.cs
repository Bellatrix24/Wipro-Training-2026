using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingEcommerceApp.Controllers
{
    public class LoginController : Controller
    {
        // Route: /Login
        public IActionResult Index()
        {
            return View();
        }
    }
}
