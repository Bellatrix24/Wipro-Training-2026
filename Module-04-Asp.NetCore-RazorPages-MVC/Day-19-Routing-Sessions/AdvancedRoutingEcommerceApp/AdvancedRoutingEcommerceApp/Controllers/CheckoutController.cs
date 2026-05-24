using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingEcommerceApp.Controllers
{
    public class CheckoutController : Controller
    {
        // Route: /Checkout?loggedIn=true or /Checkout?loggedIn=false
        public IActionResult Index(bool loggedIn = false)
        {
            if (!loggedIn)
            {
                // Redirect guest users to login page
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
