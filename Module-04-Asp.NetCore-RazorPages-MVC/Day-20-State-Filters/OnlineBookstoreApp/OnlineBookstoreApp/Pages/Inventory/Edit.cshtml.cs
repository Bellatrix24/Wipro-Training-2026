using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstoreApp.Filters;
using OnlineBookstoreApp.Models;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Pages.Inventory
{
    [TypeFilter(typeof(AuthFilter))]
    [TypeFilter(typeof(RoleFilter))]
    public class EditModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        [BindProperty]
        public Book Book { get; set; } = new Book();

        public EditModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult OnGet(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} was not found.");
            }
            Book = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookRepository.Update(Book);
            TempData["Success"] = $"Successfully updated '{Book.Title}' details!";
            return RedirectToAction("Index", "Books");
        }
    }
}
