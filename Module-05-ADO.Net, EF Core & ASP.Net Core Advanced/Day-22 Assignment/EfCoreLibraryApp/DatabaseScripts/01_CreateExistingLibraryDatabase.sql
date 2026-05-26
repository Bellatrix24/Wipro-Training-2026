-- 01_CreateExistingLibraryDatabase.sql
-- This script creates the tables for the "existing" library database.
-- In a real Database First scenario, this database would already exist
-- and you would scaffold your models from it using:
-- dotnet ef dbcontext scaffold "Server=.;Database=ExistingLibraryDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o DatabaseFirstModels

CREATE DATABASE ExistingLibraryDb;
GO

USE ExistingLibraryDb;
GO

CREATE TABLE DbFirstBooks (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    ISBN NVARCHAR(20) NULL,
    PublishYear INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL DEFAULT 0.00
);
GO
