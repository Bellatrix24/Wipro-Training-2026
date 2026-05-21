USE NFSDB;
GO

-- Dropping existing functions/procedures if they exist so the script runs without errors when we re-run it
IF OBJECT_ID('dbo.GETFULLNAME', 'FN') IS NOT NULL
    DROP FUNCTION dbo.GETFULLNAME;
GO

IF OBJECT_ID('dbo.CalculateBonus', 'FN') IS NOT NULL
    DROP FUNCTION dbo.CalculateBonus;
GO

IF OBJECT_ID('dbo.GetEmployeebyDept', 'IF') IS NOT NULL
    DROP FUNCTION dbo.GetEmployeebyDept;
GO

IF OBJECT_ID('dbo.ADDEMPLOYEE', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ADDEMPLOYEE;
GO

-- 1. SCALAR FUNCTION: dbo.GETFULLNAME
-- This is for combining names. It takes the first name and last name and joins them with a space.
-- Doing this on the database side is super useful for reports so we don't have to write CONCAT in every single query.
CREATE FUNCTION dbo.GETFULLNAME
(
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50)
)
RETURNS NVARCHAR(101)
AS
BEGIN
    RETURN CONCAT(@FirstName, ' ', @LastName);
END;
GO

-- 2. SCALAR FUNCTION: dbo.CalculateBonus
-- Adding a 10% bonus here. It takes a salary and multiplies it by 0.10.
-- Keeping the math simple so it's easy to read and understand.
CREATE FUNCTION dbo.CalculateBonus
(
    @Salary INT
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    RETURN @Salary * 0.10;
END;
GO

-- 3. INLINE TABLE-VALUED FUNCTION: dbo.GetEmployeebyDept
-- This function takes a department name and returns all employees who work in that department.
-- It returns a whole table, which is very fast in SQL because it acts like a normal query.
CREATE FUNCTION dbo.GetEmployeebyDept
(
    @dept NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT * 
    FROM dbo.Employees 
    WHERE Department = @dept
);
GO

-- 4. STORED PROCEDURE: dbo.ADDEMPLOYEE
-- Simple stored procedure to insert a new employee record.
-- I included @Age because our main table has a NOT NULL constraint on the Age column.
CREATE PROCEDURE dbo.ADDEMPLOYEE
    @EmpID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Department NVARCHAR(100),
    @Salary DECIMAL(18, 2),
    @Age INT = 30 -- Default age is set to 30 so the CHECK constraint on the table won't throw an error
AS
BEGIN
    -- We need to turn IDENTITY_INSERT on because EmployeeID is an IDENTITY column in our schema
    SET IDENTITY_INSERT dbo.Employees ON;

    INSERT INTO dbo.Employees (EmployeeID, FirstName, LastName, Age, Department, Salary)
    VALUES (@EmpID, @FirstName, @LastName, @Age, @Department, @Salary);

    -- Always turn it off right after we are done
    SET IDENTITY_INSERT dbo.Employees OFF;
END;
GO


-- ============================================================================
-- TESTING OUR FUNCTIONS AND STORED PROCEDURE
-- ============================================================================

-- Test 1: Testing the GETFULLNAME function
PRINT 'Testing GETFULLNAME:';
SELECT 
    FirstName, 
    LastName, 
    dbo.GETFULLNAME(FirstName, LastName) AS FullName
FROM dbo.Employees;
GO

-- Test 2: Testing the CalculateBonus function
PRINT 'Testing CalculateBonus (10%):';
SELECT 
    FirstName, 
    Salary, 
    dbo.CalculateBonus(Salary) AS BonusAmount
FROM dbo.Employees;
GO

-- Test 3: Testing the GetEmployeebyDept function for 'HR' and 'Engineering'
PRINT 'Testing GetEmployeebyDept for HR:';
SELECT * FROM dbo.GetEmployeebyDept('HR');
GO

PRINT 'Testing GetEmployeebyDept for Engineering:';
SELECT * FROM dbo.GetEmployeebyDept('Engineering');
GO

-- Test 4: Testing our Stored Procedure (dbo.ADDEMPLOYEE)
-- Using a transaction so we don't accidentally mess up the main table data during our test
PRINT 'Testing ADDEMPLOYEE procedure:';

BEGIN TRANSACTION;

-- Add a test employee
EXEC dbo.ADDEMPLOYEE 
    @EmpID = 100, 
    @FirstName = 'Test', 
    @LastName = 'User', 
    @Department = 'IT', 
    @Salary = 50000.00,
    @Age = 25;

-- Select it to verify it was added and check if our bonus function works with it too!
SELECT 
    EmployeeID,
    dbo.GETFULLNAME(FirstName, LastName) AS FullName,
    Department,
    Salary,
    dbo.CalculateBonus(Salary) AS Bonus
FROM dbo.Employees
WHERE EmployeeID = 100;

-- Rollback so we keep the database clean
ROLLBACK TRANSACTION;
PRINT 'Test transaction rolled back successfully. Database is clean!';
GO
