using Microsoft.AspNetCore.Mvc;

namespace WiproTraining.Day19.Controllers
{
    // This controller handles restaurant requests for our food delivery app demo.
    // We are using attribute routing here to customize our URL structures!
    [Route("restaurant")]
    public class RestaurantController : Controller
    {
        // By adding this Route attribute, we override the default routing pipeline!
        // Instead of accessing this via /Restaurant/Menu, users will go to /restaurant/our-menu
        [Route("our-menu")]
        public IActionResult Menu()
        {
            // Simple return of standard string content to keep things lightweight
            return Content("Restaurant Menu Page");
        }

        // We can also bind parameter constraints directly inside the route tag!
        // The "{id:int}" restriction guarantees that this action only fires if the ID is an integer.
        // It helps prevent errors if users try to pass words instead of database IDs in the URL.
        [Route("details/{id:int}")]
        public string Details(int id)
        {
            // We return a simple tracking message displaying the passed index variable
            return $"Showing details for restaurant number: {id}";
        }
    }
}
