using Microsoft.AspNetCore.Mvc;
using MvcFiltersBankingStoreApp.Data;
using MvcFiltersBankingStoreApp.Filters;

namespace MvcFiltersBankingStoreApp.Controllers
{
    [TypeFilter(typeof(SimpleAuthenticationFilter))]
    [TypeFilter(typeof(RoleAuthorizationFilter))]
    public class AdminController : Controller
    {
        // Route: /Admin/Users
        public IActionResult Users()
        {
            // Admins can see all bank accounts on this admin page
            var accounts = BankingStore.Accounts;
            return View(accounts);
        }
    }
}
