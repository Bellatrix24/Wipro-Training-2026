using Microsoft.EntityFrameworkCore;
using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Interfaces;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context) { }

        // Get all books with Author and Genre data loaded
        public async Task<IEnumerable<Book>> GetBooksWithDetailsAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();
        }

        // Filter books by title, author, or genre
        public async Task<IEnumerable<Book>> SearchAsync(string? title, int? authorId, int? genreId, string? sortOrder)
        {
            var query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(b => b.Title.Contains(title));

            if (authorId.HasValue)
                query = query.Where(b => b.AuthorID == authorId.Value);

            if (genreId.HasValue)
                query = query.Where(b => b.BookGenres.Any(bg => bg.GenreID == genreId.Value));

            return await ApplySorting(query, sortOrder).ToListAsync();
        }

        // Paginated list of books
        public async Task<IEnumerable<Book>> GetPagedAsync(int page, int pageSize, string? sortOrder)
        {
            var query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .AsNoTracking()
                .AsQueryable();

            return await ApplySorting(query, sortOrder)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // Replace genre associations for a book
        public async Task UpdateGenresAsync(int bookId, int[] genreIds)
        {
            var existing = _context.BookGenres.Where(bg => bg.BookID == bookId);
            _context.BookGenres.RemoveRange(existing);

            if (genreIds != null)
            {
                foreach (var gid in genreIds)
                {
                    _context.BookGenres.Add(new BookGenre { BookID = bookId, GenreID = gid });
                }
            }

            await _context.SaveChangesAsync();
        }

        private static IQueryable<Book> ApplySorting(IQueryable<Book> query, string? sortOrder)
        {
            return sortOrder switch
            {
                "title_desc" => query.OrderByDescending(b => b.Title),
                "year" => query.OrderBy(b => b.PublishYear),
                "year_desc" => query.OrderByDescending(b => b.PublishYear),
                "price" => query.OrderBy(b => b.Price),
                "price_desc" => query.OrderByDescending(b => b.Price),
                _ => query.OrderBy(b => b.Title)
            };
        }
    }
}
