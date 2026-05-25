using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStoreRestApi.Models;

namespace BookStoreRestApi.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (await context.Authors.AnyAsync() || await context.Books.AnyAsync())
            {
                return; // Database already seeded
            }

            var authors = new[]
            {
                new Author { Name = "J.K. Rowling", Biography = "British author, best known for the Harry Potter fantasy series." },
                new Author { Name = "George R.R. Martin", Biography = "American novelist and short story writer, author of A Song of Ice and Fire." },
                new Author { Name = "J.R.R. Tolkien", Biography = "English writer, poet, philologist, and academic, author of The Hobbit and The Lord of the Rings." }
            };

            context.Authors.AddRange(authors);
            await context.SaveChangesAsync();

            context.Books.AddRange(
                new Book { Title = "Harry Potter and the Sorcerer's Stone", Genre = "Fantasy", PublicationYear = 1997, Price = 19.99m, AuthorId = authors[0].Id },
                new Book { Title = "A Game of Thrones", Genre = "Fantasy", PublicationYear = 1996, Price = 24.99m, AuthorId = authors[1].Id },
                new Book { Title = "The Hobbit", Genre = "Fantasy", PublicationYear = 1937, Price = 14.99m, AuthorId = authors[2].Id },
                new Book { Title = "The Fellowship of the Ring", Genre = "Fantasy", PublicationYear = 1954, Price = 21.99m, AuthorId = authors[2].Id }
            );

            await context.SaveChangesAsync();
        }
    }
}
