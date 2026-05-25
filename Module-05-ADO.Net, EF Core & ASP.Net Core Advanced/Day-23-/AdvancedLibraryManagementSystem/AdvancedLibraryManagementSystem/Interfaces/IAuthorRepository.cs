using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsWithBooksAsync();
    }
}
