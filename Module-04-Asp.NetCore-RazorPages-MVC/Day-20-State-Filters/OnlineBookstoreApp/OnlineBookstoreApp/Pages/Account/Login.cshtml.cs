using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _userRepository.GetByUsername(Username);
            if (user == null || user.Password != Password)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }

            // Write auth credentials to session
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            TempData["Success"] = $"Welcome back, {user.Username}!";
            return RedirectToAction("Index", "Books");
        }
    }
}
