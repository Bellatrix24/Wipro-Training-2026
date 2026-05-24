using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AdvancedRoutingEcommerceApp.Data;

namespace AdvancedRoutingEcommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        // Route: /
        public IActionResult Index()
        {
            var products = ProductStore.Products;
            return View(products);
        }

        // Route: /Products/{category}/{id}
        public IActionResult Details(string category, int id)
        {
            var product = ProductStore.Products.FirstOrDefault(p => 
                p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && 
                p.Id == id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} in category '{category}' was not found.");
            }

            return View(product);
        }

        // Route: /Products/Filter/{category}/{priceRange}
        public IActionResult Filter(string category, string priceRange)
        {
            var parts = priceRange.Split('-');
            if (parts.Length == 2 && 
                decimal.TryParse(parts[0], out var minPrice) && 
                decimal.TryParse(parts[1], out var maxPrice))
            {
                var filteredProducts = ProductStore.Products.Where(p => 
                    p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && 
                    p.Price >= minPrice && 
                    p.Price <= maxPrice).ToList();

                ViewBag.Category = category;
                ViewBag.PriceRange = priceRange;
                ViewBag.MinPrice = minPrice;
                ViewBag.MaxPrice = maxPrice;

                return View(filteredProducts);
            }

            return BadRequest("Invalid price range format.");
        }
    }
}
