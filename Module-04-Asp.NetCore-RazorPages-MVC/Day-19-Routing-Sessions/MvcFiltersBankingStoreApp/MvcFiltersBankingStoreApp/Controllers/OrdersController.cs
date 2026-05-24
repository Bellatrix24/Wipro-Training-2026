using Microsoft.AspNetCore.Mvc;
using MvcFiltersBankingStoreApp.Filters;

namespace MvcFiltersBankingStoreApp.Controllers
{
    [TypeFilter(typeof(SimpleAuthenticationFilter))]
    public class OrdersController : Controller
    {
        // Route: /Orders/Checkout
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
