using System;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Represents a book in the library management system.
    /// </summary>
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
        }

        /// <summary>
        /// Marks the book as borrowed.
        /// </summary>
        public void Borrow()
        {
            IsBorrowed = true;
        }

        /// <summary>
        /// Marks the book as available (returned).
        /// </summary>
        public void Return()
        {
            IsBorrowed = false;
        }
    }
}
