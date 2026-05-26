using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EfCoreLibraryApp.Data;

namespace EfCoreLibraryApp.Controllers
{
    // Demonstrates efficient EF Core queries using Include and AsNoTracking
    public class LibraryQueryController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryQueryController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Eager loading with Include and ThenInclude
            var booksWithAuthors = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .AsNoTracking()
                .ToListAsync();

            // Query: books by a specific author
            var orwellBooks = await _context.Books
                .Where(b => b.Author != null && b.Author.Name == "George Orwell")
                .Include(b => b.Author)
                .AsNoTracking()
                .ToListAsync();

            // Query: authors with their book count
            var authorsWithCounts = await _context.Authors
                .Select(a => new { a.Name, BookCount = a.Books.Count })
                .AsNoTracking()
                .ToListAsync();

            // Query: books that belong to "Fiction" genre
            var fictionBooks = await _context.BookGenres
                .Where(bg => bg.Genre != null && bg.Genre.Name == "Fiction")
                .Include(bg => bg.Book)
                .Select(bg => bg.Book!.Title)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.AllBooks = booksWithAuthors;
            ViewBag.OrwellBooks = orwellBooks;
            ViewBag.AuthorsWithCounts = authorsWithCounts;
            ViewBag.FictionBooks = fictionBooks;

            return View();
        }
    }
}
