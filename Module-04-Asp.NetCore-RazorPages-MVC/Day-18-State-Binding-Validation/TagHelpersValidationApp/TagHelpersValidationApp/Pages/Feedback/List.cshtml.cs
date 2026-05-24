using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpersValidationApp.Models;
using TagHelpersValidationApp.Data;

namespace TagHelpersValidationApp.Pages.Feedback
{
    // Natural comment: Page model to show all submitted customer feedback records.
    public class ListModel : PageModel
    {
        public List<Models.Feedback> Feedbacks { get; set; } = new List<Models.Feedback>();

        public void OnGet()
        {
            // Load feedbacks from static data store
            Feedbacks = FeedbackStore.Feedbacks;
        }
    }
}
