using Microsoft.EntityFrameworkCore;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(e =>
            {
                e.HasKey(a => a.AuthorID);
                e.Property(a => a.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Genre>(e =>
            {
                e.HasKey(g => g.GenreID);
                e.Property(g => g.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(e =>
            {
                e.HasKey(b => b.BookID);
                e.Property(b => b.Title).IsRequired().HasMaxLength(200);
                e.Property(b => b.Price).HasColumnType("decimal(10,2)");
                e.HasOne(b => b.Author)
                 .WithMany(a => a.Books)
                 .HasForeignKey(b => b.AuthorID)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BookGenre>(e =>
            {
                e.HasKey(bg => new { bg.BookID, bg.GenreID });
                e.HasOne(bg => bg.Book).WithMany(b => b.BookGenres).HasForeignKey(bg => bg.BookID);
                e.HasOne(bg => bg.Genre).WithMany(g => g.BookGenres).HasForeignKey(bg => bg.GenreID);
            });

            // Seed data
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorID = 1, Name = "George Orwell", Bio = "English novelist." },
                new Author { AuthorID = 2, Name = "J.K. Rowling", Bio = "British author of Harry Potter." }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreID = 1, Name = "Fiction" },
                new Genre { GenreID = 2, Name = "Fantasy" },
                new Genre { GenreID = 3, Name = "Dystopian" }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1, Title = "1984", AuthorID = 1, PublishYear = 1949, Price = 12.99m },
                new Book { BookID = 2, Title = "Animal Farm", AuthorID = 1, PublishYear = 1945, Price = 9.99m },
                new Book { BookID = 3, Title = "Harry Potter and the Philosopher's Stone", AuthorID = 2, PublishYear = 1997, Price = 14.99m }
            );
            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre { BookID = 1, GenreID = 1 },
                new BookGenre { BookID = 1, GenreID = 3 },
                new BookGenre { BookID = 2, GenreID = 1 },
                new BookGenre { BookID = 3, GenreID = 2 },
                new BookGenre { BookID = 3, GenreID = 1 }
            );
        }
    }
}
