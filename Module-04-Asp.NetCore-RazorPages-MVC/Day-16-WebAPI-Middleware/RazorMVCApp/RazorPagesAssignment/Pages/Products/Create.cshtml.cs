using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAssignment.Models;

namespace RazorPagesAssignment.Pages.Products
{
    // Natural comment: Page model to add new products. 
    // It binds the Product model and a list of selected category IDs.
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new Product();

        // Complex model binding to bind selected checkboxes to a list of ints
        [BindProperty]
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();

        public List<Category> AvailableCategories { get; set; } = new List<Category>();

        public void OnGet()
        {
            // Populate checkboxes for category selection
            AvailableCategories = ProductStore.AvailableCategories;
        }

        public IActionResult OnPost()
        {
            // Make sure the static list of categories is available if we reload the view on error
            AvailableCategories = ProductStore.AvailableCategories;

            // Simple validation: check if Product ID already exists
            if (ProductStore.Products.Any(p => p.ProductID == Product.ProductID))
            {
                ModelState.AddModelError("Product.ProductID", "A product with this ID already exists. Please choose a unique ID.");
            }

            if (!ModelState.IsValid)
            {
                // Validation failed: return the form with messages
                return Page();
            }

            // Map selected category IDs to Category objects
            if (SelectedCategoryIds != null && SelectedCategoryIds.Any())
            {
                Product.Categories = ProductStore.AvailableCategories
                    .Where(c => SelectedCategoryIds.Contains(c.CategoryID))
                    .ToList();
            }

            // Add the new product to our in-memory list
            ProductStore.Products.Add(Product);

            // Redirect back to the index view
            return RedirectToPage("/Products/Index");
        }
    }
}
