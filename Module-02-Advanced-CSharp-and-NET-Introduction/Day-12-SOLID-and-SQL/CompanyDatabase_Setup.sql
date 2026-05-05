-- =============================================
-- Script: CompanyDatabase_Setup.sql
-- Description: Creates CompanyDB and Employees table with sample data.
-- =============================================

-- Create the database
CREATE DATABASE CompanyDB;
GO

USE CompanyDB;
GO

-- Create the Employees table
-- Rule 1: Use meaningful table names
-- Rule 2: Define a Primary Key
-- Rule 3: Use appropriate data types
-- Rule 4: Apply NOT NULL constraints where necessary
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL CHECK (Age >= 18),
    Department NVARCHAR(100),
    Salary DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Insert sample records
-- Rule 5: Diverse data entries
INSERT INTO Employees (FirstName, LastName, Age, Department, Salary)
VALUES 
('Amit', 'Sharma', 28, 'Engineering', 75000.00),
('Sneha', 'Reddy', 24, 'Marketing', 62000.00),
('John', 'Doe', 22, 'HR', 45000.00),
('Priya', 'Kapoor', 30, 'Finance', 85000.00),
('Vikram', 'Singh', 26, 'Engineering', 72000.00);
GO

-- Fetch all employees where Age > 23
SELECT 
    EmployeeID, 
    FirstName, 
    LastName, 
    Age, 
    Department, 
    Salary 
FROM Employees 
WHERE Age > 23;
GO
