-- ============================================================================
-- SCRIPT: Subqueries_And_Triggers_Practice.sql
-- DESCRIPTION: Everyday practice script for Subqueries and Triggers.
-- Nom: Wipro Project Engineer Trainee
-- ============================================================================

USE NFSDB;
GO

-- Let's drop the trigger and tables if they exist so we can re-run this script cleanly
IF OBJECT_ID('dbo.trg_UpdateDepartmentLocation', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_UpdateDepartmentLocation;
GO

IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL
    DROP TABLE dbo.Departments;
GO

-- ============================================================================
-- 1. SETUP THE DEPARTMENTS TABLE
-- ============================================================================

-- Creating a simple Departments table to link with our Employees
CREATE TABLE dbo.Departments (
    DeptID INT PRIMARY KEY,
    DeptName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100) NOT NULL
);
GO

-- Inserting 3 simple rows for practice
INSERT INTO dbo.Departments (DeptID, DeptName, Location)
VALUES 
(1, 'HR', 'Delhi'),
(2, 'Engineering', 'Delhi'),
(3, 'Finance', 'Mumbai');
GO

-- ============================================================================
-- 2. BASIC SCALAR SUBQUERY
-- ============================================================================

-- Checking for people who make more than the average salary of the whole company
-- The inner subquery runs first to calculate the average salary (e.g. 61800), 
-- and then the outer query filters employees who earn more than that.
SELECT 
    EmployeeID, 
    FirstName, 
    LastName, 
    Salary
FROM dbo.Employees
WHERE Salary > (SELECT AVG(Salary) FROM dbo.Employees);
GO

-- ============================================================================
-- 3. IN SUBQUERY
-- ============================================================================

-- Selecting employees who work in departments located in 'Delhi'
-- The inner query finds the names of departments in Delhi ('HR' and 'Engineering'), 
-- and then the outer query returns all employees working in those departments.
SELECT 
    EmployeeID, 
    FirstName, 
    LastName, 
    Department, 
    Salary
FROM dbo.Employees
WHERE Department IN (
    SELECT DeptName 
    FROM dbo.Departments 
    WHERE Location = 'Delhi'
);
GO

-- ============================================================================
-- 4. CORRELATED SUBQUERY
-- ============================================================================

-- Finding employees making more than the average of their specific department.
-- In a correlated subquery, the inner query references the outer query (e1.Department),
-- so it runs row-by-row to compare each employee's salary against their own department's average.
SELECT 
    e1.EmployeeID, 
    e1.FirstName, 
    e1.LastName, 
    e1.Department, 
    e1.Salary
FROM dbo.Employees e1
WHERE e1.Salary > (
    SELECT AVG(e2.Salary) 
    FROM dbo.Employees e2 
    WHERE e2.Department = e1.Department
);
GO

-- SIMPLE ALTERNATIVE: Doing the exact same thing using a JOIN
-- Instead of a subquery running row-by-row, we aggregate the averages first in a virtual table 
-- and then JOIN it to the main Employees table. This is often faster for large tables!
SELECT 
    e.EmployeeID, 
    e.FirstName, 
    e.LastName, 
    e.Department, 
    e.Salary,
    d.AvgSalary AS DeptAverage
FROM dbo.Employees e
INNER JOIN (
    SELECT Department, AVG(Salary) AS AvgSalary 
    FROM dbo.Employees 
    GROUP BY Department
) d ON e.Department = d.Department
WHERE e.Salary > d.AvgSalary;
GO

-- ============================================================================
-- 5. DML AFTER TRIGGER
-- ============================================================================

-- This trigger runs right after a new row gets added to the Employees table.
-- It automatically updates the new hire's department location to 'Updated Location' in our Departments table.
CREATE TRIGGER dbo.trg_UpdateDepartmentLocation
ON dbo.Employees
AFTER INSERT
AS
BEGIN
    -- We suppress row counts to keep output clean
    SET NOCOUNT ON;

    -- The "inserted" table is a special virtual table created by SQL Server.
    -- It holds the exact new row(s) that were just added to the Employees table.
    -- We find the department of the newly added employee and update its location in the Departments table.
    UPDATE dbo.Departments
    SET Location = 'Updated Location'
    WHERE DeptName IN (SELECT Department FROM inserted);
END;
GO

-- ============================================================================
-- 6. VERIFICATION (TESTING INDEPENDENTLY)
-- ============================================================================

-- Testing our trigger using a transaction so we don't permanently mess up the main table data during our test
PRINT '--- STARTING TRIGGER TEST ---';
BEGIN TRANSACTION;

-- Let's first check the location of the 'HR' department before the insert (should be 'Delhi')
PRINT 'HR location before insert:';
SELECT DeptName, Location FROM dbo.Departments WHERE DeptName = 'HR';

-- Adding a new employee 'John Snow' into 'HR'
-- This should fire our trigger and update the 'HR' location automatically
INSERT INTO dbo.Employees (FirstName, LastName, Age, Department, Salary)
VALUES ('John', 'Snow', 32, 'HR', 48000.00);

-- Checking the Departments table again to see if the trigger fired and updated the location to 'Updated Location'
PRINT 'HR location after trigger fires:';
SELECT DeptName, Location FROM dbo.Departments WHERE DeptName = 'HR';

-- Rollback so we keep the database clean and pristine
ROLLBACK TRANSACTION;
PRINT '--- TEST COMPLETED & TRANSACTION ROLLED BACK ---';
GO
