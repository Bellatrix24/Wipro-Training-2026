using Microsoft.AspNetCore.Mvc;

namespace MvcFiltersBankingStoreApp.Controllers
{
    public class AccountController : Controller
    {
        // Route: /Account/Login
        public IActionResult Login()
        {
            return View();
        }
    }
}
