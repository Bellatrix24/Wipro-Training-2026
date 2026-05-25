using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogRestApi.Data;
using MovieCatalogRestApi.DTOs;
using MovieCatalogRestApi.Models;

namespace MovieCatalogRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _context.Movies
                .Include(m => m.Director)
                .Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseYear = m.ReleaseYear,
                    DirectorId = m.DirectorId,
                    DirectorName = m.Director != null ? m.Director.Name : string.Empty
                })
                .ToListAsync();

            return Ok(movies);
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound(new { error = $"Movie with ID {id} not found." });
            }

            var dto = new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseYear = movie.ReleaseYear,
                DirectorId = movie.DirectorId,
                DirectorName = movie.Director != null ? movie.Director.Name : string.Empty
            };

            return Ok(dto);
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie([FromBody] MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verify if the associated director exists
            var director = await _context.Directors.FindAsync(dto.DirectorId);
            if (director == null)
            {
                return BadRequest(new { error = $"Cannot create movie: Associated Director with ID {dto.DirectorId} does not exist." });
            }

            var movie = new Movie
            {
                Title = dto.Title,
                Genre = dto.Genre,
                ReleaseYear = dto.ReleaseYear,
                DirectorId = dto.DirectorId
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            dto.Id = movie.Id;
            dto.DirectorName = director.Name;

            return CreatedAtAction(nameof(GetMovie), new { id = dto.Id }, dto);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { error = "ID mismatch in request." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verify if the movie exists
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound(new { error = $"Movie with ID {id} not found." });
            }

            // Verify if the associated director exists
            var director = await _context.Directors.FindAsync(dto.DirectorId);
            if (director == null)
            {
                return BadRequest(new { error = $"Cannot update movie: Associated Director with ID {dto.DirectorId} does not exist." });
            }

            movie.Title = dto.Title;
            movie.Genre = dto.Genre;
            movie.ReleaseYear = dto.ReleaseYear;
            movie.DirectorId = dto.DirectorId;

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound(new { error = $"Movie with ID {id} no longer exists." });
                }
                throw;
            }

            dto.DirectorName = director.Name;
            return Ok(dto);
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound(new { error = $"Movie with ID {id} not found." });
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Movie with ID {id} has been deleted successfully." });
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
