-- DatabaseScripts/01_CreateDatabase.sql
-- Use this script if connecting to a real SQL Server instead of InMemory.

CREATE DATABASE LibraryDb;
GO

USE LibraryDb;
GO

CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Bio NVARCHAR(500) NULL
);

CREATE TABLE Genres (
    GenreID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    PublishYear INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    AuthorID INT NOT NULL,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID) ON DELETE CASCADE
);

CREATE TABLE BookGenres (
    BookID INT NOT NULL,
    GenreID INT NOT NULL,
    PRIMARY KEY (BookID, GenreID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (GenreID) REFERENCES Genres(GenreID)
);
GO

INSERT INTO Authors (Name, Bio) VALUES
('George Orwell', 'English novelist.'),
('J.K. Rowling', 'British author of Harry Potter.');

INSERT INTO Genres (Name) VALUES
('Fiction'),
('Fantasy'),
('Dystopian');

INSERT INTO Books (Title, PublishYear, Price, AuthorID) VALUES
('1984', 1949, 12.99, 1),
('Animal Farm', 1945, 9.99, 1),
('Harry Potter and the Philosopher''s Stone', 1997, 14.99, 2);

INSERT INTO BookGenres (BookID, GenreID) VALUES
(1, 1),
(1, 3),
(2, 1),
(3, 2),
(3, 1);
GO
