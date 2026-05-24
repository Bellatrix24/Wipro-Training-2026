using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpersValidationApp.Models;

namespace TagHelpersValidationApp.Pages.Registration
{
    // Natural comment: Page model to manage User Registration form submission and validation.
    public class CreateModel : PageModel
    {
        [BindProperty]
        public UserRegistration Registration { get; set; } = new UserRegistration();

        public void OnGet()
        {
            // Display empty registration form
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Validation failed: return page to display individual field errors
                return Page();
            }

            // Validation passed: redirect to success view
            return RedirectToPage("/Registration/Success");
        }
    }
}
