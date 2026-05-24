using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TagHelpersValidationApp.Models;
using TagHelpersValidationApp.Data;

namespace TagHelpersValidationApp.Pages.Feedback
{
    // Natural comment: Page model to handle new feedback entries.
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Models.Feedback Feedback { get; set; } = new Models.Feedback();

        public List<SelectListItem> RatingOptions { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            PopulateRatingOptions();
        }

        public IActionResult OnPost()
        {
            PopulateRatingOptions();

            if (!ModelState.IsValid)
            {
                // Validation failed: return page showing inputs and errors
                return Page();
            }

            // Save the submitted feedback to our static store
            FeedbackStore.Feedbacks.Add(Feedback);

            // Redirect to list page to display submissions
            return RedirectToPage("/Feedback/List");
        }

        private void PopulateRatingOptions()
        {
            RatingOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- Select Rating --" },
                new SelectListItem { Value = "5", Text = "5 Stars - Excellent" },
                new SelectListItem { Value = "4", Text = "4 Stars - Very Good" },
                new SelectListItem { Value = "3", Text = "3 Stars - Good" },
                new SelectListItem { Value = "2", Text = "2 Stars - Fair" },
                new SelectListItem { Value = "1", Text = "1 Star - Poor" }
            };
        }
    }
}
