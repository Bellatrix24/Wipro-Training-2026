using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiddlewareRazorPagesApp.Models;

namespace MiddlewareRazorPagesApp.Pages.Items
{
    // Natural comment: Page model to handle creating new items via form property binding.
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Item Item { get; set; } = new Item();

        public void OnGet()
        {
            // Just display the empty form page
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Form input has validation errors: reload page showing errors
                return Page();
            }

            // Save the newly created item to our in-memory static store
            ItemStore.Items.Add(Item);

            // Redirect back to the items catalog list page
            return RedirectToPage("/Items/Index");
        }
    }
}
