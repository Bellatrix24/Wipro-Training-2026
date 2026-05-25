using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManagementPlatform.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("ManageTasks", "Admin");
            }
            return RedirectToAction("TaskList", "User");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
