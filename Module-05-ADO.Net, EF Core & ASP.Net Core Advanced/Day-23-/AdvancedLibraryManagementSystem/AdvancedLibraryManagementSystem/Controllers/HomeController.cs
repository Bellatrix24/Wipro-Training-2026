using Microsoft.AspNetCore.Mvc;

namespace AdvancedLibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
