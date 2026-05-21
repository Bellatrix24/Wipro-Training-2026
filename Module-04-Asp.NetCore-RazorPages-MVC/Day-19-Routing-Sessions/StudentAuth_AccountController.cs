using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WiproTraining.Day19.Controllers
{
    // This controller handles login and user tracking state in our lab demo
    public class AccountController : Controller
    {
        // This handles our standard student login form submissions
        [HttpPost]
        public IActionResult Login(string username)
        {
            // If the user left the login field blank, we just return them back
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index");
            }

            // We save the username securely in our server-side Session state.
            // This token helps the server recognize the user across different page clicks!
            HttpContext.Session.SetString("UserName", username);

            // Once the session token is saved, we redirect them to their secure dashboard
            return RedirectToAction("Dashboard");
        }

        // Displays the user's dashboard page by fetching the active session token
        public IActionResult Dashboard()
        {
            // We safely read the tracking username token back out of the Session state
            string activeUser = HttpContext.Session.GetString("UserName");

            // If no user is logged in, we send them back to the login page
            if (string.IsNullOrEmpty(activeUser))
            {
                return RedirectToAction("Index");
            }

            // We store the username inside ViewBag so our display views can show it
            ViewBag.User = activeUser;

            // We return a simple content string showing the active session user
            return Content($"Welcome {ViewBag.User} to your dashboard!");
        }
    }
}
