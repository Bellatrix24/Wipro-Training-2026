-- DatabaseScripts/01_Setup.sql
-- Setup Database Script for BookStoreRestApi (SQL Server / SQLite compatible)

CREATE DATABASE BookStoreDb;
GO

USE BookStoreDb;
GO

-- Authors Table
CREATE TABLE [Authors] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Biography] NVARCHAR(500) NULL
);

-- Books Table
CREATE TABLE [Books] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(150) NOT NULL,
    [Genre] NVARCHAR(50) NOT NULL,
    [PublicationYear] INT NOT NULL,
    [Price] DECIMAL(18,2) NOT NULL,
    [AuthorId] INT NOT NULL,
    FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([Id]) ON DELETE CASCADE
);
GO

-- Seed Authors
INSERT INTO [Authors] ([Name], [Biography]) VALUES 
('J.K. Rowling', 'British author, best known for the Harry Potter fantasy series.'),
('George R.R. Martin', 'American novelist and short story writer, author of A Song of Ice and Fire.'),
('J.R.R. Tolkien', 'English writer, poet, philologist, and academic, author of The Hobbit and The Lord of the Rings.');

-- Seed Books
INSERT INTO [Books] ([Title], [Genre], [PublicationYear], [Price], [AuthorId]) VALUES
('Harry Potter and the Sorcerer''s Stone', 'Fantasy', 1997, 19.99, 1),
('A Game of Thrones', 'Fantasy', 1996, 24.99, 2),
('The Hobbit', 'Fantasy', 1937, 14.99, 3),
('The Fellowship of the Ring', 'Fantasy', 1954, 21.99, 3);
GO
