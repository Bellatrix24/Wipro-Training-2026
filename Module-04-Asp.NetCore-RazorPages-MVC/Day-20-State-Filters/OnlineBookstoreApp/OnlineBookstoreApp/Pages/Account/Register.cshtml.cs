using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstoreApp.Models;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        [BindProperty]
        public UserAccount UserAccount { get; set; } = new UserAccount();

        public RegisterModel(IUserRepository userRepository)
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

            var existing = _userRepository.GetByUsername(UserAccount.Username);
            if (existing != null)
            {
                ModelState.AddModelError("UserAccount.Username", "Username is already taken.");
                return Page();
            }

            _userRepository.Add(UserAccount);
            TempData["Success"] = "Registration successful! Please login below.";
            return RedirectToPage("/Account/Login");
        }
    }
}
