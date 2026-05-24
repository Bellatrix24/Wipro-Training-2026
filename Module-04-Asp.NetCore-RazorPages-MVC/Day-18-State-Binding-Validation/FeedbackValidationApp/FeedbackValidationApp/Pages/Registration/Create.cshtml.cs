using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FeedbackValidationApp.Models;

namespace FeedbackValidationApp.Pages.Registration
{
    // Natural comment: Page model to manage User Registration form submission and validation pipelines.
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
                // Validation failed on server side, return the form with errors
                return Page();
            }

            // Registration data validated successfully, redirect to the success view
            return RedirectToPage("/Registration/Success");
        }
    }
}
