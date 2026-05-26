using System;
using Microsoft.AspNetCore.Mvc;

namespace Day28AJAXCoreDemo.Controllers
{
    // Hey diary! This is our standard HomeController.
    // It's a simple trainee lab class that demonstrates how we return raw JSON data streams 
    // to jQuery background requests instead of returning heavy visual HTML views!
    public class HomeController : Controller
    {
        // GET: /Home/Index
        // Simply renders our empty view skeleton to bootstrap our client scripts.
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/GetMessage
        // This is our dedicated endpoint decorated with [HttpGet] to tell the routing engine
        // that it only accepts GET requests.
        [HttpGet]
        public JsonResult GetMessage()
        {
            // Hey diary! Bypassing a complete page reload by returning raw JSON data strings instead.
            // This maps directly to a lightweight JSON string value: {"message": "AJAX Call Successful"}.
            // This string travels quickly down the network pipeline without carrying heavy HTML template bloat!
            return Json(new { message = "AJAX Call Successful" });
        }
    }
}
