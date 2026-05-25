using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineBookstoreApp.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "You have been successfully logged out.";
            return RedirectToAction("Index", "Books");
        }
    }
}
