-- Create Database if not exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BookstoreAdoDb')
BEGIN
    CREATE DATABASE BookstoreAdoDb;
END
GO

USE BookstoreAdoDb;
GO

-- Create Books table if not exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Books')
BEGIN
    CREATE TABLE Books (
        BookId INT IDENTITY(1,1) PRIMARY KEY,
        Title NVARCHAR(150) NOT NULL,
        Author NVARCHAR(100) NOT NULL,
        ISBN NVARCHAR(30) NOT NULL,
        Price DECIMAL(10,2) NOT NULL
    );
END
GO
