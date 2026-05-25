using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Interfaces;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryContext context) : base(context) { }
    }
}
