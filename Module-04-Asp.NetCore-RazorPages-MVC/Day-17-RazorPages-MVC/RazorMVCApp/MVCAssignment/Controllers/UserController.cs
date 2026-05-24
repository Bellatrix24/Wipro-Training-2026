using Microsoft.AspNetCore.Mvc;
using MVCAssignment.Models;

namespace MVCAssignment.Controllers
{
    // Natural comment: Controller to manage User views.
    // Demonstrates simple and complex nested model binding in action.
    public class UserController : Controller
    {
        // Natural comment: Static field to temporarily save the submitted user data.
        // This is used to display details on the Result view since we don't have a database.
        private static User? _submittedUser;

        // GET: /User/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return the form with validation errors.
                return View(user);
            }

            // Save the valid user data to our static store
            _submittedUser = user;

            // Redirect to the Result page to avoid double-posts
            return RedirectToAction("Result");
        }

        // GET: /User/Result
        [HttpGet]
        public IActionResult Result()
        {
            if (_submittedUser == null)
            {
                // If no user has been submitted yet, redirect to the form
                return RedirectToAction("Create");
            }

            return View(_submittedUser);
        }
    }
}
