using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksWithDetailsAsync();
        Task<IEnumerable<Book>> SearchAsync(string? title, int? authorId, int? genreId, string? sortOrder);
        Task<IEnumerable<Book>> GetPagedAsync(int page, int pageSize, string? sortOrder);
        Task UpdateGenresAsync(int bookId, int[] genreIds);
    }
}
