using Microsoft.AspNetCore.Mvc;
using AdvancedLibraryManagementSystem.Interfaces;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _books;
        private readonly IAuthorRepository _authors;
        private readonly IGenreRepository _genres;

        public BooksController(IBookRepository books, IAuthorRepository authors, IGenreRepository genres)
        {
            _books = books;
            _authors = authors;
            _genres = genres;
        }

        public async Task<IActionResult> Index(string? title, int? authorId, int? genreId, string? sortOrder, int page = 1)
        {
            const int pageSize = 5;
            IEnumerable<Book> books;

            if (!string.IsNullOrEmpty(title) || authorId.HasValue || genreId.HasValue)
                books = await _books.SearchAsync(title, authorId, genreId, sortOrder);
            else
                books = await _books.GetPagedAsync(page, pageSize, sortOrder);

            ViewBag.Authors = await _authors.GetAllAsync();
            ViewBag.Genres = await _genres.GetAllAsync();
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.Title = title;
            ViewBag.AuthorId = authorId;
            ViewBag.GenreId = genreId;
            ViewBag.SortOrder = sortOrder;
            return View(books);
        }

        // Returns the create form partial for AJAX modal
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _authors.GetAllAsync();
            ViewBag.Genres = await _genres.GetAllAsync();
            return PartialView("_CreateEditPartial", new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, int[] selectedGenres)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Validation failed." });

            try
            {
                await _books.AddAsync(book);
                await _books.UpdateGenresAsync(book.BookID, selectedGenres);
                return Json(new { success = true, message = "Book added successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _books.GetByIdAsync(id);
            if (book == null) return NotFound();

            var full = (await _books.GetBooksWithDetailsAsync()).FirstOrDefault(b => b.BookID == id);
            ViewBag.Authors = await _authors.GetAllAsync();
            ViewBag.Genres = await _genres.GetAllAsync();
            ViewBag.SelectedGenres = full?.BookGenres.Select(bg => bg.GenreID).ToList() ?? new List<int>();
            return PartialView("_CreateEditPartial", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book, int[] selectedGenres)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Validation failed." });

            try
            {
                await _books.UpdateAsync(book);
                await _books.UpdateGenresAsync(book.BookID, selectedGenres);
                return Json(new { success = true, message = "Book updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _books.DeleteAsync(id);
                return Json(new { success = true, message = "Book deleted." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
