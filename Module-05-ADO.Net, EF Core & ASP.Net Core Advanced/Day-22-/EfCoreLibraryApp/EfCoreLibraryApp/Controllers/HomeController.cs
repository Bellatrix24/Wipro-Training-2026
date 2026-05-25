using Microsoft.AspNetCore.Mvc;

namespace EfCoreLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
