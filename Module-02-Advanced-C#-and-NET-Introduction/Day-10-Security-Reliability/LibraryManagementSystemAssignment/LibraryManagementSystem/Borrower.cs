using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Represents a library borrower.
    /// </summary>
    public class Borrower
    {
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Borrower(string name, string libraryCardNumber)
        {
            Name = name;
            LibraryCardNumber = libraryCardNumber;
            BorrowedBooks = new List<Book>();
        }

        /// <summary>
        /// Adds a book to the borrower's list and marks the book as borrowed.
        /// </summary>
        public void BorrowBook(Book book)
        {
            if (book != null)
            {
                BorrowedBooks.Add(book);
                book.Borrow();
            }
        }

        /// <summary>
        /// Removes a book from the borrower's list and marks the book as returned.
        /// </summary>
        public void ReturnBook(Book book)
        {
            if (book != null)
            {
                BorrowedBooks.Remove(book);
                book.Return();
            }
        }
    }
}
