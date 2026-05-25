using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstoreApp.Filters;
using OnlineBookstoreApp.Models;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Pages.Inventory
{
    [TypeFilter(typeof(AuthFilter))]
    [TypeFilter(typeof(RoleFilter))]
    public class AddModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        [BindProperty]
        public Book Book { get; set; } = new Book();

        public AddModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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

            _bookRepository.Add(Book);
            TempData["Success"] = $"Successfully added '{Book.Title}' to book repository!";
            return RedirectToAction("Index", "Books");
        }
    }
}
