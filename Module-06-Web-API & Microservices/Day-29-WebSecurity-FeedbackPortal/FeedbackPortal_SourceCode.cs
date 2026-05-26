using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Day29WebSecurityFeedbackPortal
{
    // Hey diary! This UserComment class represents our incoming feedback data model.
    // We apply strict validation attributes to block any malicious inputs before they can proceed.
    public class UserComment
    {
        [Required(ErrorMessage = "Name is mandatory!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        // Restrict input characters to letters and spaces only. This blocks script characters like < or >!
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Comment is mandatory!")]
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string CommentText { get; set; }
    }

    // Hey diary! This is our FeedbackController.
    // It implements our GET/POST actions and applies anti-forgery tokens to protect against CSRF exploits.
    public class FeedbackController : Controller
    {
        // GET: /Feedback/Create
        // Renders our secure submission form view.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Feedback/Create
        // Handles comment submissions securely.
        [HttpPost]
        // Hey diary! This token validation protects our backend endpoints from forged external form posts (CSRF)!
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserComment model)
        {
            // Verify if the input satisfies all our structural model validation data attributes
            if (!ModelState.IsValid)
            {
                // If validation failed, re-render the form cleanly, displaying localized error spans.
                return View(model);
            }

            // If inputs are safe, pass the parameters through to our Success landing page.
            // We pass the data securely as a route value object.
            return RedirectToAction(nameof(Success), new { name = model.Name, commentText = model.CommentText });
        }

        // GET: /Feedback/Success
        // Displays the successfully validated and sanitized user comments.
        [HttpGet]
        public IActionResult Success(string name, string commentText)
        {
            var model = new UserComment
            {
                Name = name,
                CommentText = commentText
            };
            return View(model);
        }
    }
}
