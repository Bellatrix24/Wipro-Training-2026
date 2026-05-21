using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WiproTraining.Day17.Pages
{
    // Our page backend inherits from PageModel to handle Razor Page requests
    public class SimpleBinding_IndexModel : PageModel
    {
        // This binds data from the URL query string (like: ?SearchName=Wipro)
        // Perfect for search boxes or filters!
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        // This binds data from standard HTML forms when sending a POST request.
        // It captures data from a form post securely in the background.
        [BindProperty]
        public string Name { get; set; }

        // This runs automatically when the page first loads up in the browser
        public void OnGet()
        {
            // If the user entered a search query, we can put our search filtering logic here.
            if (!string.IsNullOrEmpty(SearchName))
            {
                // We would query our database or list here to filter employees by SearchName.
            }
        }

        // This runs automatically when the user clicks a submit button on a form
        public void OnPost()
        {
            // This is where we process the form data.
            // For example, we can check if the Name field is empty, or save it to a list.
            if (!string.IsNullOrEmpty(Name))
            {
                // Our business logic goes here to save or process the Name.
            }
        }
    }
}
