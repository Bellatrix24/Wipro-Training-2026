using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AdvancedRoutingEcommerceApp.Data;

namespace AdvancedRoutingEcommerceApp.Controllers
{
    public class UsersController : Controller
    {
        // Route: /Users/{username}/Orders
        public IActionResult Orders(string username)
        {
            var userOrders = OrderStore.Orders.Where(o => 
                o.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();

            ViewBag.Username = username;
            return View(userOrders);
        }
    }
}
