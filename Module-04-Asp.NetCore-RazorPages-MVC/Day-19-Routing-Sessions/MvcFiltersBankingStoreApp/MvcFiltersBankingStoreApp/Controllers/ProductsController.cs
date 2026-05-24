using Microsoft.AspNetCore.Mvc;
using MvcFiltersBankingStoreApp.Data;

namespace MvcFiltersBankingStoreApp.Controllers
{
    public class ProductsController : Controller
    {
        // Route: /Products
        public IActionResult Index()
        {
            var products = ProductStore.Products;
            return View(products);
        }
    }
}
