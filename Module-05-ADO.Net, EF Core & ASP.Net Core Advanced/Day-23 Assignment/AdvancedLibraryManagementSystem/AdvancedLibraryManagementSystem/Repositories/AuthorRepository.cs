using Microsoft.EntityFrameworkCore;
using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Interfaces;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context) { }

        public async Task<IEnumerable<Author>> GetAuthorsWithBooksAsync()
        {
            return await _context.Authors
                .Include(a => a.Books)
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync();
        }
    }
}
