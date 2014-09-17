-- 1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
-- A: SQL Structured Query Language is a special-purpose programming language designed for managing data held in a relational database management system (RDBMS).
-- A relational database can be accessed and modified by executing SQL statements
--  SQL allows
-- 	- Defining / modifying the database schema
-- 	- Searching / modifying table data
-- 	- A set of SQL commands are available for extracting subset of the table data
-- A data manipulation language (DML) is a family of syntax elements similar to a computer programming language used for selecting, inserting, deleting and updating data in a database. - SELECT, UPDATE, INSERT, DELETE
-- A data definition language or data description language (DDL) is a syntax similar to a computer programming language for defining data structures, especially database schemas - CREATE, ALTER, RENAME, DROP, GRANT, REVOKE

-- 2. What is Transact-SQL (T-SQL)?
-- T-SQL (Transact SQL) is an extension to the standard SQL language
-- 	- T-SQL is the standard language used in MS SQL Server
-- 	- Supports if statements, loops, exceptions
-- 	- Constructions used in the high-level procedural programming languages
-- 	- T-SQL is used for writing stored procedures, functions, triggers, etc.

-- 3. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.

-- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * 
FROM Departments

-- 5. Write a SQL query to find all department names.
SELECT Departments.Name
FROM Departments

-- 6. Write a SQL query to find the salary of each employee.
SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e

-- 7. Write a SQL to find the full name of each employee.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
FROM Employees e

-- 8. Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
SELECT e.FirstName + '.' + e.LastName + '@telerik.com' AS [Full Email Address]
FROM Employees e

-- 9. Write a SQL query to find all different employee salaries.
SELECT DISTINCT e.Salary, MIN(e.FirstName + ' ' + e.LastName) AS [EmployeeName] 
FROM Employees e
GROUP BY e.Salary

-- 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT *
FROM Employees e
WHERE e.JobTitle LIKE '%sales representative%'

-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT e.FirstName + ' ' + e.LastName AS [Name]
FROM Employees e
WHERE e.FirstName LIKE 'sa%'

-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT e.FirstName + ' ' + e.LastName AS [Name]
FROM Employees e
WHERE e.LastName LIKE '%ei%'

-- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT e.FirstName + ' ' + e.LastName AS [Name], e.Salary
FROM Employees e
WHERE e.Salary BETWEEN 20000 AND 30000

-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT e.FirstName + ' ' + e.LastName AS [Name], e.Salary
FROM Employees e
WHERE e.Salary IN (25000, 14000, 12500, 23600)

-- 15. Write a SQL query to find all employees that do not have manager.
SELECT e.FirstName + ' ' + e.LastName AS [Name], e.Salary
FROM Employees e
WHERE e.ManagerID IS NULL

-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT e.FirstName + ' ' + e.LastName AS [Name], e.Salary
FROM Employees e
WHERE e.Salary>=50000
ORDER by e.Salary DESC

-- 17. Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 e.FirstName + ' ' + e.LastName AS [Name], e.Salary
FROM Employees e
WHERE e.Salary>=50000
ORDER by e.Salary DESC

-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName + ' ' + e.LastName AS [Name], a.AddressText
FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID=a.AddressID

-- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName + ' ' + e.LastName AS [Name], a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID=a.AddressID

-- 20. Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName AS [Name],
 m.FirstName + ' ' + m.LastName AS [Manager Name]
	FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID=m.EmployeeID

-- 21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName + ' ' + e.LastName AS [Name],
 m.FirstName + ' ' + m.LastName AS [Manager Name], a.AddressText
	FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID=m.EmployeeID
	INNER JOIN Addresses a
		ON e.AddressID=a.AddressID

-- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT d.Name
	FROM Departments d
	UNION
SELECT t.Name
	FROM Towns t
	
-- 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName AS [Name],
 m.FirstName + ' ' + m.LastName AS [Manager Name], a.AddressText
	FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID=m.EmployeeID
	INNER JOIN Addresses a
		ON e.AddressID=a.AddressID
ORDER BY m.EmployeeID

-- 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	e.HireDate, d.Name AS [Department Name]
	FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name IN ('Sales', 'Finance') 
	AND YEAR(e.HireDate) BETWEEN 1995 AND 2005