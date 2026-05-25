-- 02_SampleData.sql
-- Insert sample data into the existing library database.

USE ExistingLibraryDb;
GO

INSERT INTO DbFirstBooks (Title, ISBN, PublishYear, Price) VALUES
('The Great Gatsby', '978-0743273565', 1925, 12.99),
('Moby Dick', '978-1503280786', 1851, 9.99),
('Pride and Prejudice', '978-1503290563', 1813, 7.99);
GO
