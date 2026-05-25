using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Route: /Books
        public IActionResult Index()
        {
            var books = _bookRepository.GetAll();
            return View(books);
        }

        // Route: /Books/Details/{id:int}
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                // Throws exception to demonstrate exception handler
                throw new System.Exception($"Book with ID {id} was not found in our catalog.");
            }
            return View(book);
        }
    }
}
