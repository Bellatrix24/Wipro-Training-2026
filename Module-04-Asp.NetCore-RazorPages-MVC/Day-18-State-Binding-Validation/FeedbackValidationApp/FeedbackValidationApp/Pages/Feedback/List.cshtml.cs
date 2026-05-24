using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FeedbackValidationApp.Models;

namespace FeedbackValidationApp.Pages.Feedback
{
    // Natural comment: Page model to display all submitted customer feedbacks.
    public class ListModel : PageModel
    {
        public List<Models.Feedback> Feedbacks { get; set; } = new List<Models.Feedback>();

        public void OnGet()
        {
            // Populate list from our in-memory static store
            Feedbacks = FeedbackStore.Feedbacks;
        }
    }
}
