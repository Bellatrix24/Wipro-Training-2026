using Microsoft.AspNetCore.Mvc;

// ============================================================================
// STUDY BLOCK 1: ATTRIBUTE ROUTING (Highly preferred for RESTful APIs)
// ============================================================================

namespace SmartInventory.Controllers
{
    // The [ApiController] attribute tells ASP.NET Core that this controller serves API data,
    // which automatically handles model validation and returns HTTP 400 if validation fails.
    [ApiController]
    // The [Route] attribute sets the base path. Here, "[controller]" acts as a placeholder
    // that resolves to the controller's class name minus the "Controller" suffix (so "products").
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Trainee Study Note:
        // When a client sends a GET request to "/api/products/101", the routing system searches
        // for a matching route. 
        // 1. "api/products" matches the class-level Route.
        // 2. "/101" matches the HttpGet parameter "{id}" defined below.
        // The router parses the "101" from the URL and binds it directly to the 'id' parameter in our method!
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            // Just simulating a database search for today's practice
            var product = new
            {
                ProductId = id,
                Name = "Smart Scanner Tool",
                StockLevel = 45,
                WarehouseCode = "WH-NORTHEAST"
            };

            return Ok(product);
        }
    }
}

// ============================================================================
// STUDY BLOCK 2: CONVENTIONAL ROUTING (Used for MVC / HTML web views)
// ============================================================================

namespace SmartInventory.Controllers
{
    // This is a standard MVC controller inheriting from the base Controller class (not ControllerBase).
    // It doesn't have [Route] attributes on it because it relies on the global rules mapped in Program.cs.
    public class HomeController : Controller
    {
        // Trainee Study Note:
        // In Program.cs, we have a general pattern setup: "{controller=Home}/{action=Index}/{id?}".
        // When a user navigates to "http://localhost:5001/", the framework reads the default rules:
        // - No controller specified? Default to "Home".
        // - No action specified? Default to "Index".
        // So the request is routed straight to the Index() method here.
        public IActionResult Index()
        {
            return View();
        }
    }
}
