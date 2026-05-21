using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WiproTraining.Day18.Pages
{
    // This backend handles our daily employee feedback portal form
    public class FeedbackModel_IndexModel : PageModel
    {
        // Simple standard property for showing the employee name on screen (display only)
        public string EmployeeName { get; set; } = "Alex Rivera";

        // This property binds securely to the form's text input
        // We added a student validation attribute to make sure they actually typed something!
        [BindProperty]
        [Required(ErrorMessage = "feedback is required...!!!")]
        public string Feedback { get; set; }

        // We can store our friendly alert messages in this property to show them on the HTML view
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
            // When the page first loads, we don't need to do any validation check yet
        }

        public void OnPost()
        {
            // This stops the process if the user missed a field or typed invalid data!
            if (!ModelState.IsValid)
            {
                // We return early so the page reloads and displays the red error messages
                return;
            }

            // If we reach here, it means the validation checks passed perfectly!
            // We can now save this feedback to a list or database safely.
            SuccessMessage = "Feedback submitted successfully! Thank you for helping us improve.";
        }
    }
}
