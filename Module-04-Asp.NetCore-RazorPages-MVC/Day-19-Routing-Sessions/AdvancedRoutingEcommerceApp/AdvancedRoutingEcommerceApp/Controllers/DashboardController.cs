using System;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingEcommerceApp.Controllers
{
    public class DashboardController : Controller
    {
        // Route: /Dashboard?role=admin or /Dashboard?role=user
        public IActionResult Index(string role)
        {
            if (string.Equals(role, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View("Admin");
            }
            return View("User");
        }
    }
}
