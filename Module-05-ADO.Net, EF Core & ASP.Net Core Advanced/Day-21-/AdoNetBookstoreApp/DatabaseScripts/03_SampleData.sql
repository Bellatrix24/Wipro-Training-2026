USE BookstoreAdoDb;
GO

-- Insert sample book records if the table is empty
IF NOT EXISTS (SELECT TOP 1 * FROM Books)
BEGIN
    INSERT INTO Books (Title, Author, ISBN, Price)
    VALUES 
    (N'ADO.NET Fundamentals', N'Elisabeth Freeman', N'978-0-596-00712-6', 45.99),
    (N'SQL Server Architecture', N'Robert C. Martin', N'978-0-13-449416-6', 55.00),
    (N'Disconnected Data Patterns', N'Mark Seemann', N'978-1-935182-47-4', 39.99);
END
GO
