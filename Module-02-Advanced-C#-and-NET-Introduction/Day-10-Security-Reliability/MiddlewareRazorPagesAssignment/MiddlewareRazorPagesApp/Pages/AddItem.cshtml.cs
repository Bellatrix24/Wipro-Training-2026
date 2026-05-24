using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiddlewareRazorPagesApp.Services;

namespace MiddlewareRazorPagesApp.Pages
{
    public class AddItemModel : PageModel
    {
        private readonly ItemStore _itemStore = new ItemStore();

        [BindProperty]
        [Required(ErrorMessage = "Item Name is required.")]
        [StringLength(50, ErrorMessage = "Item Name must be between 2 and 50 characters.", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string Description { get; set; } = string.Empty;

        public void OnGet()
        {
            // Simply render the empty form
        }

        public IActionResult OnPost()
        {
            // Simple model validation
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save to static store
            _itemStore.Add(Name, Description);

            // Redirect back to listing page as requested
            return RedirectToPage("/Items");
        }
    }
}
