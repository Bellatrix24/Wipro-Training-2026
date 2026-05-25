using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreRestApi.Data;
using BookStoreRestApi.DTOs;
using BookStoreRestApi.Models;

namespace BookStoreRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = b.Genre,
                    PublicationYear = b.PublicationYear,
                    Price = b.Price,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author != null ? b.Author.Name : string.Empty
                })
                .ToListAsync();

            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound(new { error = $"Book with ID {id} not found." });
            }

            var dto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                PublicationYear = book.PublicationYear,
                Price = book.Price,
                AuthorId = book.AuthorId,
                AuthorName = book.Author != null ? book.Author.Name : string.Empty
            };

            return Ok(dto);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verify if the associated author exists
            var author = await _context.Authors.FindAsync(dto.AuthorId);
            if (author == null)
            {
                return BadRequest(new { error = $"Cannot create book: Associated Author with ID {dto.AuthorId} does not exist." });
            }

            var book = new Book
            {
                Title = dto.Title,
                Genre = dto.Genre,
                PublicationYear = dto.PublicationYear,
                Price = dto.Price,
                AuthorId = dto.AuthorId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            dto.Id = book.Id;
            dto.AuthorName = author.Name;

            return CreatedAtAction(nameof(GetBook), new { id = dto.Id }, dto);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { error = "ID mismatch in request." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verify if the book exists
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound(new { error = $"Book with ID {id} not found." });
            }

            // Verify if the associated author exists
            var author = await _context.Authors.FindAsync(dto.AuthorId);
            if (author == null)
            {
                return BadRequest(new { error = $"Cannot update book: Associated Author with ID {dto.AuthorId} does not exist." });
            }

            book.Title = dto.Title;
            book.Genre = dto.Genre;
            book.PublicationYear = dto.PublicationYear;
            book.Price = dto.Price;
            book.AuthorId = dto.AuthorId;

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound(new { error = $"Book with ID {id} no longer exists." });
                }
                throw;
            }

            dto.AuthorName = author.Name;
            return Ok(dto);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound(new { error = $"Book with ID {id} not found." });
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Book with ID {id} has been deleted successfully." });
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
