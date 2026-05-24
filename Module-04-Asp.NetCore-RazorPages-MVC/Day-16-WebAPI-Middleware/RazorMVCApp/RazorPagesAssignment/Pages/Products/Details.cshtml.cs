using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAssignment.Models;

namespace RazorPagesAssignment.Pages.Products
{
    // Natural comment: Page model for details page.
    // It accepts a custom integer route parameter to retrieve the matching product.
    public class DetailsModel : PageModel
    {
        public Product? Product { get; set; }

        public IActionResult OnGet(int id)
        {
            // Find the product matching the route ID parameter
            Product = ProductStore.Products.FirstOrDefault(p => p.ProductID == id);

            if (Product == null)
            {
                // If not found, send back to the list
                return RedirectToPage("/Products/Index");
            }

            return Page();
        }
    }
}
