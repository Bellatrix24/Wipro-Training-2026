using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfCoreLibraryApp.Data;
using EfCoreLibraryApp.Models;

namespace EfCoreLibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .ToListAsync();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "Name");
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                // Add genre associations
                if (selectedGenres != null)
                {
                    foreach (var genreId in selectedGenres)
                    {
                        _context.BookGenres.Add(new BookGenre { BookID = book.BookID, GenreID = genreId });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "Name");
            ViewBag.Genres = _context.Genres.ToList();
            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
                .Include(b => b.BookGenres)
                .FirstOrDefaultAsync(b => b.BookID == id);
            if (book == null) return NotFound();

            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "Name", book.AuthorID);
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.SelectedGenres = book.BookGenres.Select(bg => bg.GenreID).ToList();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book, int[] selectedGenres)
        {
            if (id != book.BookID) return NotFound();

            if (ModelState.IsValid)
            {
                // Remove old genre links
                var oldGenres = _context.BookGenres.Where(bg => bg.BookID == id);
                _context.BookGenres.RemoveRange(oldGenres);

                // Update book
                _context.Update(book);

                // Add new genre links
                if (selectedGenres != null)
                {
                    foreach (var genreId in selectedGenres)
                    {
                        _context.BookGenres.Add(new BookGenre { BookID = book.BookID, GenreID = genreId });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "Name", book.AuthorID);
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.SelectedGenres = selectedGenres?.ToList() ?? new List<int>();
            return View(book);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.BookID == id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
