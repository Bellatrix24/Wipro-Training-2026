using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstoreApp.Filters;
using OnlineBookstoreApp.Models;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Pages.Inventory
{
    [TypeFilter(typeof(AuthFilter))]
    [TypeFilter(typeof(RoleFilter))]
    public class DeleteModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public Book Book { get; set; } = new Book();

        public DeleteModel(IBookRepository bookRepository)
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

        public IActionResult OnPost(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book != null)
            {
                _bookRepository.Delete(id);
                TempData["Success"] = $"Successfully deleted '{book.Title}' from inventory catalog!";
            }
            return RedirectToAction("Index", "Books");
        }
    }
}
