using System;
using Microsoft.AspNetCore.Mvc;

namespace MvcFiltersBankingStoreApp.Controllers
{
    public class ErrorDemoController : Controller
    {
        // Route: /ErrorDemo/Throw
        public IActionResult Throw()
        {
            throw new Exception("This is a simulated error to verify the Global Exception Filter works correctly.");
        }
    }
}
