USE BookstoreAdoDb;
GO

-- Stored Procedure to Add a Book
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddBook')
BEGIN
    DROP PROCEDURE AddBook;
END
GO

CREATE PROCEDURE AddBook
    @Title NVARCHAR(150),
    @Author NVARCHAR(100),
    @ISBN NVARCHAR(30),
    @Price DECIMAL(10,2),
    @BookId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Books (Title, Author, ISBN, Price)
    VALUES (@Title, @Author, @ISBN, @Price);
    
    SET @BookId = SCOPE_IDENTITY();
END
GO

-- Stored Procedure to Update a Book
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateBook')
BEGIN
    DROP PROCEDURE UpdateBook;
END
GO

CREATE PROCEDURE UpdateBook
    @BookId INT,
    @Title NVARCHAR(150),
    @Author NVARCHAR(100),
    @ISBN NVARCHAR(30),
    @Price DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Books
    SET Title = @Title,
        Author = @Author,
        ISBN = @ISBN,
        Price = @Price
    WHERE BookId = @BookId;
END
GO

-- Stored Procedure to Delete a Book
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteBook')
BEGIN
    DROP PROCEDURE DeleteBook;
END
GO

CREATE PROCEDURE DeleteBook
    @BookId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM Books
    WHERE BookId = @BookId;
END
GO
