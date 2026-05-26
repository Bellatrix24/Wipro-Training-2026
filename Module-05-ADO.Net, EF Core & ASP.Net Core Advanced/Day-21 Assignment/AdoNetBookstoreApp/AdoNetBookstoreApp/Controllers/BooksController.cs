using Microsoft.AspNetCore.Mvc;
using AdoNetBookstoreApp.DataAccess;
using AdoNetBookstoreApp.Models;

namespace AdoNetBookstoreApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDataAccess _dataAccess;

        public BooksController(BookDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // Route: /Books
        public IActionResult Index()
        {
            var books = _dataAccess.GetAllBooks();
            return View(books);
        }

        // Route: /Books/Details/{id}
        public IActionResult Details(int id)
        {
            var book = _dataAccess.GetBookById(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} was not found.");
            }
            return View(book);
        }

        // Route: /Books/Create (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Route: /Books/Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.AddBook(book);
                TempData["Success"] = $"Successfully added '{book.Title}'!";
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // Route: /Books/Edit/{id} (GET)
        public IActionResult Edit(int id)
        {
            var book = _dataAccess.GetBookById(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} was not found.");
            }
            return View(book);
        }

        // Route: /Books/Edit/{id} (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.UpdateBook(book);
                TempData["Success"] = $"Successfully updated '{book.Title}' details!";
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // Route: /Books/Delete/{id} (GET)
        public IActionResult Delete(int id)
        {
            var book = _dataAccess.GetBookById(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} was not found.");
            }
            return View(book);
        }

        // Route: /Books/Delete/{id} (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dataAccess.DeleteBook(id);
            TempData["Success"] = "Successfully deleted the book from the database!";
            return RedirectToAction(nameof(Index));
        }
    }
}
