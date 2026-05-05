/* 
   SQL SECURITY AND DATA CONTROL LANGUAGE (DCL)
   Focus: Enforcing the Principle of Least Privilege.
*/

-- 1. SERVER LEVEL SECURITY: Creating a Login
-- A login allows a person to connect to the SQL Server instance.
USE master;
GO

CREATE LOGIN User1Login WITH PASSWORD = 'StrongPassword123!';
GO

-- 2. DATABASE LEVEL SECURITY: Creating a User
-- A user allows the login to access a specific database (NFSDB).
USE NFSDB;
GO

CREATE USER User1 FOR LOGIN User1Login;
GO

-- 3. PERMISSIONS: Using GRANT
-- We give User1 only the permissions they NEED to do their job.
GRANT SELECT, INSERT, UPDATE ON dbo.Customers TO User1;
GO

-- 4. ROLE MANAGEMENT: Simplifying Permission Control
-- Instead of granting permissions to every user individually, we use Roles.

-- Create the Role
CREATE ROLE NewRole;
GO

-- Grant permissions to the Role
GRANT SELECT ON dbo.Orders TO NewRole;
GO

-- Add the User to the Role
ALTER ROLE NewRole ADD MEMBER User1;
GO

-- 5. REVOKE AND DROP: The Lifecycle of Security
-- Revoking specific permissions without removing the user
REVOKE UPDATE ON dbo.Customers FROM User1;
GO

-- Removing the user from the role
ALTER ROLE NewRole DROP MEMBER User1;
GO

-- Cleaning up (Dropping the role)
DROP ROLE NewRole;
GO

-- Final Note: User1 now only has SELECT and INSERT on Customers, and is no longer part of NewRole.
