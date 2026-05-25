-- DatabaseScripts/01_Setup.sql
-- Setup Database Script for SecureDatabaseSecurityPortal

CREATE DATABASE SecureDatabasePortalDb;
GO

USE SecureDatabasePortalDb;
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

CREATE TABLE [AspNetUserRoles] (
    [UserId] NVARCHAR(450) NOT NULL,
    [RoleId] NVARCHAR(450) NOT NULL,
    PRIMARY KEY ([UserId], [RoleId]),
    FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE,
    FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles]([Id]) ON DELETE CASCADE
);

-- Core Business Application Tables
CREATE TABLE [CustomerRecords] (
    [RecordId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FullName] NVARCHAR(100) NOT NULL,
    [EncryptedTaxId] NVARCHAR(MAX) NOT NULL,
    [TaxIdHmac] NVARCHAR(MAX) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NOT NULL
);

CREATE TABLE [AuditLogs] (
    [LogId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserEmail] NVARCHAR(100) NOT NULL,
    [Action] NVARCHAR(100) NOT NULL,
    [Details] NVARCHAR(MAX) NOT NULL,
    [Timestamp] DATETIME2 NOT NULL,
    [IsSuspicious] BIT NOT NULL
);
GO

-- Seed roles and admin
INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName]) VALUES 
('1', 'Admin', 'ADMIN'),
('2', 'User', 'USER');
GO

PRINT 'SecureDatabasePortalDb setup completed successfully.';
