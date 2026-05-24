using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryManagementSystem.Tests
{
    [TestClass]
    public class LibraryTests
    {
        private Library _library = null!;
        private Book _book = null!;
        private Borrower _borrower = null!;

        [TestInitialize]
        public void Setup()
        {
            _library = new Library();
            _book = new Book("The Clean Coder", "Robert C. Martin", "978-0137081073");
            _borrower = new Borrower("Alice Smith", "L100-2026");
        }

        [TestMethod]
        public void AddBook_AddsBookToLibrary()
        {
            // Act
            bool result = _library.AddBook(_book);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, _library.ViewBooks().Count);
            Assert.AreEqual(_book, _library.ViewBooks()[0]);
        }

        [TestMethod]
        public void RegisterBorrower_AddsBorrowerToLibrary()
        {
            // Act
            bool result = _library.RegisterBorrower(_borrower);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, _library.ViewBorrowers().Count);
            Assert.AreEqual(_borrower, _library.ViewBorrowers()[0]);
        }

        [TestMethod]
        public void BorrowBook_MarksBookAsBorrowed()
        {
            // Arrange
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);

            // Act
            bool result = _library.BorrowBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(_book.IsBorrowed);
        }

        [TestMethod]
        public void BorrowBook_AddsBookToBorrower()
        {
            // Arrange
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);

            // Act
            bool result = _library.BorrowBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, _borrower.BorrowedBooks.Count);
            Assert.AreEqual(_book, _borrower.BorrowedBooks[0]);
        }

        [TestMethod]
        public void ReturnBook_MarksBookAsAvailable()
        {
            // Arrange
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);
            _library.BorrowBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Act
            bool result = _library.ReturnBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(_book.IsBorrowed);
        }

        [TestMethod]
        public void ReturnBook_RemovesBookFromBorrower()
        {
            // Arrange
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);
            _library.BorrowBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Act
            bool result = _library.ReturnBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, _borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ViewBooks_ReturnsAllBooks()
        {
            // Arrange
            var secondBook = new Book("Refactoring", "Martin Fowler", "978-0134757599");
            _library.AddBook(_book);
            _library.AddBook(secondBook);

            // Act
            List<Book> books = _library.ViewBooks();

            // Assert
            Assert.IsNotNull(books);
            Assert.AreEqual(2, books.Count);
        }

        [TestMethod]
        public void ViewBorrowers_ReturnsAllBorrowers()
        {
            // Arrange
            var secondBorrower = new Borrower("Bob Jones", "L101-2026");
            _library.RegisterBorrower(_borrower);
            _library.RegisterBorrower(secondBorrower);

            // Act
            List<Borrower> borrowers = _library.ViewBorrowers();

            // Assert
            Assert.IsNotNull(borrowers);
            Assert.AreEqual(2, borrowers.Count);
        }

        [TestMethod]
        public void BorrowBook_WithInvalidIsbn_ReturnsFalse()
        {
            // Arrange
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);

            // Act
            bool result = _library.BorrowBook("INVALID-ISBN", _borrower.LibraryCardNumber);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(_book.IsBorrowed);
            Assert.AreEqual(0, _borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void BorrowBook_WithInvalidLibraryCard_ReturnsFalse()
        {
            // Arrange
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);

            // Act
            bool result = _library.BorrowBook(_book.ISBN, "INVALID-CARD");

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(_book.IsBorrowed);
        }

        [TestMethod]
        public void BorrowBook_WhenBookAlreadyBorrowed_ReturnsFalse()
        {
            // Arrange
            var otherBorrower = new Borrower("Charlie Green", "L102-2026");
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);
            _library.RegisterBorrower(otherBorrower);

            // Borrow the book to the first borrower
            _library.BorrowBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Act: Try borrowing it again to another borrower
            bool result = _library.BorrowBook(_book.ISBN, otherBorrower.LibraryCardNumber);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, _borrower.BorrowedBooks.Count);
            Assert.AreEqual(0, otherBorrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ReturnBook_WhenBookWasNotBorrowed_ReturnsFalse()
        {
            // Arrange
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);

            // Act: Book has not been borrowed yet
            bool result = _library.ReturnBook(_book.ISBN, _borrower.LibraryCardNumber);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(_book.IsBorrowed);
            Assert.AreEqual(0, _borrower.BorrowedBooks.Count);
        }
    }
}
