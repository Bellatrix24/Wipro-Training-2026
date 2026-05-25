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
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _context.Authors
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Biography = a.Biography
                })
                .ToListAsync();

            return Ok(authors);
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound(new { error = $"Author with ID {id} not found." });
            }

            var dto = new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography
            };

            return Ok(dto);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] AuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = new Author
            {
                Name = dto.Name,
                Biography = dto.Biography
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            dto.Id = author.Id;

            return CreatedAtAction(nameof(GetAuthor), new { id = dto.Id }, dto);
        }

        // PUT: api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { error = "ID mismatch in request." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound(new { error = $"Author with ID {id} not found." });
            }

            author.Name = dto.Name;
            author.Biography = dto.Biography;

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound(new { error = $"Author with ID {id} no longer exists." });
                }
                throw;
            }

            return Ok(dto);
        }

        // DELETE: api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound(new { error = $"Author with ID {id} not found." });
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Author with ID {id} and all their associated books have been deleted." });
        }

        // GET: api/authors/5/books
        [HttpGet("{authorId}/books")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthor(int authorId)
        {
            var authorExists = await _context.Authors.AnyAsync(a => a.Id == authorId);
            if (!authorExists)
            {
                return NotFound(new { error = $"Author with ID {authorId} not found." });
            }

            var books = await _context.Books
                .Where(b => b.AuthorId == authorId)
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

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
