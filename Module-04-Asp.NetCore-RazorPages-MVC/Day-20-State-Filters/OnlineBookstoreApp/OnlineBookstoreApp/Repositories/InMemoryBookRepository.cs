using System.Collections.Generic;
using System.Linq;
using OnlineBookstoreApp.Models;

namespace OnlineBookstoreApp.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        private static readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "C# Design Patterns", Author = "Elisabeth Freeman", ISBN = "978-0-596-00712-6", Price = 49.99m },
            new Book { Id = 2, Title = "Clean Architecture", Author = "Robert C. Martin", ISBN = "978-0-13-449416-6", Price = 39.99m },
            new Book { Id = 3, Title = "Dependency Injection in .NET", Author = "Mark Seemann", ISBN = "978-1-935182-47-4", Price = 45.00m }
        };

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book? GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void Update(Book book)
        {
            var existing = GetById(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.ISBN = book.ISBN;
                existing.Price = book.Price;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _books.Remove(existing);
            }
        }
    }
}
