using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Coordinates books and borrowers in the library.
    /// </summary>
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Borrower> Borrowers { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        /// <summary>
        /// Adds a book to the library system.
        /// </summary>
        public bool AddBook(Book book)
        {
            if (book == null) return false;

            // Simple validation to avoid duplicate ISBN additions
            if (Books.Any(b => b.ISBN == book.ISBN))
            {
                return false;
            }

            Books.Add(book);
            return true;
        }

        /// <summary>
        /// Registers a borrower with the library system.
        /// </summary>
        public bool RegisterBorrower(Borrower borrower)
        {
            if (borrower == null) return false;

            // Simple validation to avoid duplicate card registrations
            if (Borrowers.Any(b => b.LibraryCardNumber == borrower.LibraryCardNumber))
            {
                return false;
            }

            Borrowers.Add(borrower);
            return true;
        }

        /// <summary>
        /// Borrows a book based on its ISBN and the borrower's library card number.
        /// </summary>
        public bool BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            // Verify both exist and the book is not already borrowed
            if (book != null && borrower != null && !book.IsBorrowed)
            {
                borrower.BorrowBook(book);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a borrowed book based on its ISBN and the borrower's library card number.
        /// </summary>
        public bool ReturnBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            // Verify both exist and that this borrower actually has this book in their borrowed list
            if (book != null && borrower != null && borrower.BorrowedBooks.Contains(book))
            {
                borrower.ReturnBook(book);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the complete list of books.
        /// </summary>
        public List<Book> ViewBooks()
        {
            return Books;
        }

        /// <summary>
        /// Returns the complete list of registered borrowers.
        /// </summary>
        public List<Borrower> ViewBorrowers()
        {
            return Borrowers;
        }
    }
}
