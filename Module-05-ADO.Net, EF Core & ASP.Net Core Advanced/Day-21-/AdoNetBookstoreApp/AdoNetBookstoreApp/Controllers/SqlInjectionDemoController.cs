using Microsoft.AspNetCore.Mvc;

namespace AdoNetBookstoreApp.Controllers
{
    public class SqlInjectionDemoController : Controller
    {
        // Route: /SqlInjectionDemo
        public IActionResult Index(string searchInput)
        {
            var input = searchInput ?? string.Empty;

            // Simulated Unsafe Query text
            ViewBag.UnsafeQuery = $"SELECT * FROM Books WHERE Title = '{input}';";

            // Simulated Safe Query text (using SqlParameter)
            ViewBag.SafeQuery = "SELECT * FROM Books WHERE Title = @Title;";
            ViewBag.ParameterDeclaration = $"@Title (SqlDbType.NVarChar) = \"{input}\"";

            ViewBag.SearchInput = input;
            return View();
        }
    }
}
