using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureApp.Controllers
{
    // This acts like a bouncer checking the user's role before letting them view any page in this controller.
    // By putting it here on the class, the entire controller is locked down to "Admin" users only.
    [Authorize(Roles = "Admin")]
    public class AdminSecureController : Controller
    {
        // GET: /AdminSecure/Dashboard
        // Anyone with the "Admin" role can access this welcome view.
        public IActionResult Dashboard()
        {
            // Simple trainee study reminder: We can also inspect the current user's claims directly in code if we want to!
            var adminName = User.Identity?.Name ?? "Admin User";
            ViewBag.WelcomeMessage = $"Welcome to the Command Center, {adminName}!";
            
            return View();
        }

        // GET: /AdminSecure/SecretReports
        // Even though they are an Admin, they also need to pass the "RequireSuperUserClaim" policy check.
        // This is a Claims-based authorization check. In Program.cs, this policy would check if the user
        // possesses a specific claim (like a "ClearanceLevel" claim with the value "Level-5").
        [Authorize(Policy = "RequireSuperUserClaim")]
        public IActionResult SecretReports()
        {
            // Trainee note: Claims allow us to store custom values on the user's cookie identity,
            // like checking if they have a specific employee number or security clearance level.
            return View();
        }
    }
}
