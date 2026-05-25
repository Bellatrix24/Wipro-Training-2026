-- DatabaseScripts/01_Setup.sql
-- Setup Database Script for SecureTaskManagementPlatform

CREATE DATABASE SecureTaskManagementDb;
GO

USE SecureTaskManagementDb;
GO

-- Standard ASP.NET Core Identity Tables
CREATE TABLE [AspNetRoles] (
    [Id] NVARCHAR(450) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(256) NULL,
    [NormalizedName] NVARCHAR(256) NULL,
    [ConcurrencyStamp] NVARCHAR(MAX) NULL
);

CREATE TABLE [AspNetUsers] (
    [Id] NVARCHAR(450) NOT NULL PRIMARY KEY,
    [FullName] NVARCHAR(MAX) NOT NULL,
    [UserName] NVARCHAR(256) NULL,
    [NormalizedUserName] NVARCHAR(256) NULL,
    [Email] NVARCHAR(256) NULL,
    [NormalizedEmail] NVARCHAR(256) NULL,
    [EmailConfirmed] BIT NOT NULL,
    [PasswordHash] NVARCHAR(MAX) NULL,
    [SecurityStamp] NVARCHAR(MAX) NULL,
    [ConcurrencyStamp] NVARCHAR(MAX) NULL,
    [PhoneNumber] NVARCHAR(MAX) NULL,
    [PhoneNumberConfirmed] BIT NOT NULL,
    [TwoFactorEnabled] BIT NOT NULL,
    [LockoutEnd] DATETIMEOFFSET NULL,
    [LockoutEnabled] BIT NOT NULL,
    [AccessFailedCount] INT NOT NULL
);

CREATE TABLE [AspNetUserClaims] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserId] NVARCHAR(450) NOT NULL,
    [ClaimType] NVARCHAR(MAX) NULL,
    [ClaimValue] NVARCHAR(MAX) NULL,
    FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserRoles] (
    [UserId] NVARCHAR(450) NOT NULL,
    [RoleId] NVARCHAR(450) NOT NULL,
    PRIMARY KEY ([UserId], [RoleId]),
    FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE,
    FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles]([Id]) ON DELETE CASCADE
);

-- Core Business Application Tables
CREATE TABLE [Tasks] (
    [TaskId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(150) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [IsCompleted] BIT NOT NULL,
    [DueDate] DATETIME2 NOT NULL,
    [UserId] NVARCHAR(450) NOT NULL,
    FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Comments] (
    [CommentId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Content] NVARCHAR(MAX) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [TaskId] INT NOT NULL,
    [UserId] NVARCHAR(450) NOT NULL,
    FOREIGN KEY ([TaskId]) REFERENCES [Tasks]([TaskId]) ON DELETE CASCADE,
    FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
);
GO

-- Seed Basic Reference Values
INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName]) VALUES 
('1', 'Admin', 'ADMIN'),
('2', 'User', 'USER');
GO

PRINT 'SecureTaskManagementDb database schema setup successfully.';
