using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAssignment.Models;

namespace RazorPagesAssignment.Pages.Products
{
    // Natural comment: Page model for the products list page.
    // We load our products from the in-memory ProductStore static list.
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
            Products = ProductStore.Products;
        }
    }
}
