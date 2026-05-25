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
    public class DirectorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DirectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetDirectors()
        {
            var directors = await _context.Directors
                .Select(d => new DirectorDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Bio = d.Bio
                })
                .ToListAsync();

            return Ok(directors);
        }

        // GET: api/directors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetDirector(int id)
        {
            var director = await _context.Directors.FindAsync(id);

            if (director == null)
            {
                return NotFound(new { error = $"Director with ID {id} not found." });
            }

            var dto = new DirectorDto
            {
                Id = director.Id,
                Name = director.Name,
                Bio = director.Bio
            };

            return Ok(dto);
        }

        // POST: api/directors
        [HttpPost]
        public async Task<ActionResult<DirectorDto>> CreateDirector([FromBody] DirectorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var director = new Director
            {
                Name = dto.Name,
                Bio = dto.Bio
            };

            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            dto.Id = director.Id;

            return CreatedAtAction(nameof(GetDirector), new { id = dto.Id }, dto);
        }

        // PUT: api/directors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDirector(int id, [FromBody] DirectorDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { error = "ID mismatch in request." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound(new { error = $"Director with ID {id} not found." });
            }

            director.Name = dto.Name;
            director.Bio = dto.Bio;

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
                {
                    return NotFound(new { error = $"Director with ID {id} no longer exists." });
                }
                throw;
            }

            return Ok(dto);
        }

        // DELETE: api/directors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound(new { error = $"Director with ID {id} not found." });
            }

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Director with ID {id} and all their associated movies have been deleted." });
        }

        // GET: api/directors/5/movies
        [HttpGet("{directorId}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesByDirector(int directorId)
        {
            var directorExists = await _context.Directors.AnyAsync(d => d.Id == directorId);
            if (!directorExists)
            {
                return NotFound(new { error = $"Director with ID {directorId} not found." });
            }

            var movies = await _context.Movies
                .Where(m => m.DirectorId == directorId)
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

        private bool DirectorExists(int id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }
    }
}
