using Microsoft.EntityFrameworkCore;
using EfCoreLibraryApp.Models;

namespace EfCoreLibraryApp.Data
{
    // Code First DbContext with Fluent API configuration
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Author config
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.AuthorID);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Bio).HasMaxLength(500);
            });

            // Book config
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookID);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(200);

                // One-to-many: Author -> Books
                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Genre config
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.GenreID);
                entity.Property(g => g.Name).IsRequired().HasMaxLength(50);
            });

            // BookGenre many-to-many join table
            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasKey(bg => new { bg.BookID, bg.GenreID });

                entity.HasOne(bg => bg.Book)
                      .WithMany(b => b.BookGenres)
                      .HasForeignKey(bg => bg.BookID);

                entity.HasOne(bg => bg.Genre)
                      .WithMany(g => g.BookGenres)
                      .HasForeignKey(bg => bg.GenreID);
            });

            // Seed some data so the app is not empty
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorID = 1, Name = "George Orwell", Bio = "English novelist known for 1984 and Animal Farm." },
                new Author { AuthorID = 2, Name = "J.K. Rowling", Bio = "British author of the Harry Potter series." },
                new Author { AuthorID = 3, Name = "Harper Lee", Bio = "American novelist who wrote To Kill a Mockingbird." }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreID = 1, Name = "Fiction" },
                new Genre { GenreID = 2, Name = "Fantasy" },
                new Genre { GenreID = 3, Name = "Dystopian" },
                new Genre { GenreID = 4, Name = "Classic" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1, Title = "1984", AuthorID = 1 },
                new Book { BookID = 2, Title = "Animal Farm", AuthorID = 1 },
                new Book { BookID = 3, Title = "Harry Potter and the Philosopher's Stone", AuthorID = 2 },
                new Book { BookID = 4, Title = "To Kill a Mockingbird", AuthorID = 3 }
            );

            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre { BookID = 1, GenreID = 1 },
                new BookGenre { BookID = 1, GenreID = 3 },
                new BookGenre { BookID = 2, GenreID = 1 },
                new BookGenre { BookID = 3, GenreID = 2 },
                new BookGenre { BookID = 3, GenreID = 1 },
                new BookGenre { BookID = 4, GenreID = 1 },
                new BookGenre { BookID = 4, GenreID = 4 }
            );
        }
    }
}
