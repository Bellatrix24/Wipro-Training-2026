-- DatabaseScripts/01_Setup.sql
-- Setup Database Script for MovieCatalogRestApi (SQL Server / SQLite compatible)

CREATE DATABASE MovieCatalogDb;
GO

USE MovieCatalogDb;
GO

-- Directors Table
CREATE TABLE [Directors] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Bio] NVARCHAR(500) NULL
);

-- Movies Table
CREATE TABLE [Movies] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(150) NOT NULL,
    [Genre] NVARCHAR(50) NOT NULL,
    [ReleaseYear] INT NOT NULL,
    [DirectorId] INT NOT NULL,
    FOREIGN KEY ([DirectorId]) REFERENCES [Directors]([Id]) ON DELETE CASCADE
);
GO

-- Seed Directors
INSERT INTO [Directors] ([Name], [Bio]) VALUES 
('Christopher Nolan', 'Acclaimed director known for cerebral, nonlinear storytelling.'),
('Steven Spielberg', 'One of the most influential directors in cinema history.'),
('Quentin Tarantino', 'Known for stylized violence, sharp dialogue, and pop culture references.');

-- Seed Movies
INSERT INTO [Movies] ([Title], [Genre], [ReleaseYear], [DirectorId]) VALUES
('Inception', 'Sci-Fi', 2010, 1),
('Interstellar', 'Sci-Fi', 2014, 1),
('Jurassic Park', 'Adventure', 1993, 2),
('Pulp Fiction', 'Crime', 1994, 3);
GO
