/*1.
Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
Use a nested SELECT statement.
*/
SELECT  e.FirstName + ' ' + e.LastName AS [EmployeeName] ,
        e.Salary
FROM    Employees AS e
WHERE   e.Salary = ( SELECT MIN(Employees.Salary)
                     FROM   Employees
                   )

/*2.
Write a SQL query to find the names and salaries of the employees that have a salary 
that is up to 10% higher than the minimal salary for the company.
*/
SELECT  e.FirstName + ' ' + e.LastName AS [EmployeeName] ,
        e.Salary
FROM    Employees AS e
WHERE   e.Salary <= ( SELECT    MIN(Employees.Salary) * 1.1
                      FROM      Employees
                    )
  
/*3.
Write a SQL query to find the full name, salary and department of the employees that take 
the minimal salary in their department. Use a nested SELECT statement.
*/
SELECT  e.FirstName + ' ' + e.LastName AS [Employee Name] ,
        e.Salary ,
        d.Name AS [Department Name]
FROM    Employees AS e
        INNER JOIN dbo.Departments d
            ON d.DepartmentID = e.DepartmentID
WHERE   e.Salary = ( SELECT MIN(Salary)
                     FROM   Employees em
                     WHERE  em.DepartmentID = e.DepartmentID
                   )
ORDER BY e.DepartmentID


 
 /*4.
 Write a SQL query to find the average salary in the department #1.
 */
SELECT  AVG(e.Salary) ,
        d.Name AS [Department Name]
FROM    dbo.Departments AS d
        INNER JOIN dbo.Employees e
            ON d.DepartmentID = e.DepartmentID
WHERE   d.DepartmentID = 1
GROUP BY d.Name
 
 /*5.
 Write a SQL query to find the average salary in the "Sales" department.
 */
SELECT  AVG(e.Salary) AS [Avarage Salary],
        d.Name AS [Department Name]
FROM    dbo.Departments AS d
        INNER JOIN dbo.Employees e
            ON d.DepartmentID = e.DepartmentID
WHERE   d.Name LIKE '%Sale%'
GROUP BY d.Name
 
 /*6.
 Write a SQL query to find the number of employees in the "Sales" department.
 */
SELECT  COUNT(*) AS [Employees Number],
        d.Name AS [Department Name]
FROM    dbo.Departments AS d
        INNER JOIN dbo.Employees e
            ON d.DepartmentID = e.DepartmentID
WHERE   d.Name LIKE '%Sale%'
GROUP BY d.Name
 
/*7.
Write a SQL query to find the number of all employees that have manager.
*/
SELECT  COUNT(*) AS [Employees with Manager]
FROM    dbo.Employees e
WHERE	ManagerID IS NOT NULL
 
/*8.
Write a SQL query to find the number of all employees that have no manager.
*/
SELECT  COUNT(*) AS [Employees without Manager]
FROM    dbo.Employees e
WHERE	ManagerID IS NULL
 
/*9.
Write a SQL query to find all departments and the average salary for each of them.
*/
SELECT  d.Name AS [Department Name] ,
        AVG(e.Salary) AS [Department Avarage Salary]
FROM    dbo.Departments d
        INNER JOIN dbo.Employees e
            ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
 
 /*10.
 Write a SQL query to find the count of all employees in each department and for each town.
 */
SELECT  COUNT(e.EmployeeID) AS [Employees Count],
		d.Name AS [Department Name],
		t.Name AS [Town Name]
FROM    dbo.Employees e
         JOIN dbo.Departments d
            ON e.DepartmentID = d.DepartmentID
         JOIN dbo.Addresses a
            ON a.AddressID = e.AddressID
         JOIN dbo.Towns t
            ON t.TownID = a.TownID
GROUP BY t.Name, d.Name
 
/*11.
Write a SQL query to find all managers that have exactly 5 employees. 
Display their first name and last name.
*/
SELECT  *
FROM    ( SELECT    m.FirstName + ' ' + m.LastName AS [Manager Name] ,
                    COUNT(e.EmployeeID) AS [EmployeeCount]
          FROM      dbo.Employees e
                    INNER JOIN dbo.Employees m
                        ON e.ManagerID = m.EmployeeID
          GROUP BY  m.FirstName ,
                    m.LastName
        ) AS [Manager]
WHERE   Manager.EmployeeCount = 5
  
  ----------------------------------------------------------
  
 SELECT  COUNT(e.EmployeeID) AS EmployeeCount ,
        m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM    dbo.Employees e
        INNER JOIN dbo.Employees m
            ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, 
		m.LastName
HAVING COUNT(e.EmployeeID) = 5
 
 ----------------------------------------------------------
 
SELECT  COUNT(*) AS EmployeeCount ,
        m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM    dbo.Employees e
        INNER JOIN dbo.Employees m
            ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName ,
        m.LastName
HAVING  COUNT(*) = 5
 
/*12.
Write a SQL query to find all employees along with their managers. 
For employees that do not have manager display the value "(no manager)".
*/
SELECT  e.FirstName + ' ' + e.LastName AS [Employee Name] ,
        ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager Name]
FROM    dbo.Employees e
        LEFT JOIN dbo.Employees m
            ON e.ManagerID = m.EmployeeID
 
/*13.
Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
Use the built-in LEN(str) function.
*/
SELECT e.LastName
FROM dbo.Employees e
WHERE LEN(LastName)=5
 
 /*14.
 Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 
 Search in Google to find how to format dates in SQL Server.
 */
 
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff');
 -----------------------------------------------------------
SELECT convert(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114)
 
 /*15.
 Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
 Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
 Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
 Define a check constraint to ensure the password is at least 5 characters long.
 */
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](30) NOT NULL UNIQUE,
	[FullName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[LastLoginTime] [datetime] NULL,
	CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
	CONSTRAINT [CC_Users] CHECK ((LEN([Password]) >= 5))
)

/*16.
Write a SQL statement to create a view that displays the users from the Users table 
that have been in the system today. Test if the view works correctly.
*/

CREATE VIEW dbo.RecentUsers AS
SELECT Username,
	   FullName,
	   [Password],
	   LastLoginTime
  FROM Users
 WHERE DATEDIFF(d, LastLoginTime, GETDATE()) = 0

/*17.
Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
Define primary key and identity column.
*/

CREATE TABLE [dbo].[Groups](
	[GroupId] [int] IDENTITY,
	[GroupName] [nvarchar](30) NOT NULL UNIQUE,
	CONSTRAINT [PK_Groups] PRIMARY KEY ([GroupId]),
)

/*18.
Write a SQL statement to add a column GroupID to the table Users. 
Fill some data in this new column and as well in the Groups table. 
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
*/
ALTER TABLE Users ADD [GroupId] int NULL;
ALTER TABLE Users ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY ([GroupId])
  REFERENCES Groups([GroupId]);

/*19.
Write SQL statements to insert several records in the Users and Groups tables.
*/
INSERT [Groups] (GroupName) VALUES ('Admin')
INSERT [Groups] (GroupName) VALUES ('Registred vistor')
INSERT [Groups] (GroupName) VALUES ('Unregistered')

INSERT [Users] (Username, FullName, [Password], LastLoginTime, GroupId) 
VALUES ('laika', 'First dog to the Moon Laika', 'topSecretRussianMission', '09/06/1987', 1)
INSERT [Users] (Username, FullName, [Password], LastLoginTime, GroupId) 
VALUES ('putin', 'Vladimir Putin', 'vladkoVodkata', '12/08/2012', 2)


/*20.
Write SQL statements to update some of the records in the Users and Groups tables.
*/
UPDATE Users
SET LastLoginTime = '01/01/2010'
WHERE Username = 'student'

UPDATE Groups
SET GroupName = 'Some bad group'
WHERE GroupId = 6

UPDATE Groups
SET GroupName = 'Moderator'
WHERE GroupId = 7

UPDATE Groups
SET GroupName = 'Alcoholics'
WHERE GroupId = 8

/*21.
Write SQL statements to delete some of the records from the Users and Groups tables.
*/
DELETE FROM Users
WHERE UserId IN (1, 6)

DELETE FROM Groups
WHERE GroupId = 8

/*22.
Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
Use the same for the password, and NULL for last login time.
*/
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY,
	[Username] [nvarchar](30) NOT NULL UNIQUE,
	[FullName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[GroupId] int NULL,
	CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
	CONSTRAINT [FK_Users_Groups] 
	FOREIGN KEY ([GroupId])
	REFERENCES Groups([GroupId])
);

INSERT INTO Users (Username, FullName, [Password])
SELECT LOWER(LEFT(Emp.FirstName, 1) + Emp.LastName),
	   Emp.FirstName + ' ' + Emp.LastName, 
	   LOWER(LEFT(Emp.FirstName, 1) + Emp.LastName) -- the password should be at least 5 characters
FROM Employees AS Emp

/*23.
Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
*/
UPDATE Users
SET [Password] = NULL
WHERE DATEDIFF(d, LastLoginTime, '03/10/2010') >= 0

/*24.
Write a SQL statement that deletes all users without passwords (NULL password).
*/
DELETE FROM Users
WHERE Password IS NULL

/*25.
Write a SQL query to display the average employee salary by department and job title.
*/
 SELECT e.JobTitle ,
        d.Name AS [Department Name] ,
        AVG(e.Salary) AS [Avarage Salary],
		COUNT(*) AS [Employee Count]
FROM    dbo.Employees e
        JOIN dbo.Departments d
            ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle ,
        d.Name
 
/*26.
Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
*/
SELECT  d.Name AS [Department Name] ,
        e.JobTitle ,
        MIN(e.Salary) AS [Minimal Salary] ,
        MIN(e.FirstName + ' ' + e.LastName) AS [Employee Name]
FROM    dbo.Employees e
        JOIN dbo.Departments d
            ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle ,
        d.Name
 
/*27.
Write a SQL query to display the town where maximal number of employees work.
*/
SELECT TOP 1
        t.Name ,
        COUNT(*) AS [Employee Count]
FROM    dbo.Employees e
        INNER JOIN dbo.Addresses a
            ON e.AddressID = a.AddressID
        INNER JOIN dbo.Towns t
            ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Employee Count] DESC 

 
/*28.
Write a SQL query to display the number of managers from each town.
*/
SELECT  COUNT(e.EmployeeID) AS [Manager Count],
        t.Name
FROM    dbo.Employees e
        INNER JOIN dbo.Addresses a
            ON e.AddressID = a.AddressID
        INNER JOIN dbo.Towns t
            ON t.TownID = a.TownID
WHERE   e.EmployeeID IN ( SELECT DISTINCT
                                    e.ManagerID
                          FROM      dbo.Employees e
                          WHERE     e.ManagerID IS NOT NULL )
GROUP BY t.Name
ORDER BY [Manager Count] DESC
 
/*29.
Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
Don't forget to define  identity, primary key and appropriate foreign key. Issue few SQL statements to insert, update and delete of some data in the table.
Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
For each change keep the old record data, the new record data and the command (insert / update / delete).
*/
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkReports](
	[WorkReportID] [int] IDENTITY,
	[EmployeeID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Task] [nvarchar](30) NOT NULL,
	[Hours] [int] NOT NULL,
	[Comments] [nvarchar](30) NULL,
	CONSTRAINT [PK_WorkReports] PRIMARY KEY ([WorkReportID]),
	CONSTRAINT [FK_WorkReports_Employees] 
	FOREIGN KEY ([EmployeeID])
	REFERENCES Employees ([EmployeeID])
)
GO

INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (1, '07/11/2013', 'Bug fixing', 8)
INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (15, '01/08/2012', 'Code refactoring', 3)
INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (18, '09/09/2013', 'Software Documentation', 6)
INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (66, '09/10/2014', 'Testing', 1)
GO

UPDATE [WorkReports]
SET [Hours] = 7
WHERE EmployeeID = 15

DELETE FROM [WorkReports]
WHERE EmployeeID = 66

CREATE TABLE [dbo].[WorkReportsLogs](
	[WorkReportID] [int],
	[EmployeeID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Task] [nvarchar](30) NOT NULL,
	[Hours] [int] NOT NULL,
	[Comments] [nvarchar](30) NULL,
	[Action] [nvarchar](30) NOT NULL,
	CONSTRAINT [CC_WorkReportsLogs] CHECK (([Action] in 
	('Insert', 'Delete', 'DeleteAsPartOfUpdate', 'InsertAsPartOfUpdate')))
)
GO

CREATE TRIGGER tr_InsertWorkReports ON WorkReports FOR INSERT
AS
INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'Insert'
      FROM inserted
GO

CREATE TRIGGER tr_DeleteWorkReports ON WorkReports FOR DELETE
AS
INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'Delete'
      FROM deleted
GO

CREATE TRIGGER tr_UpdateWorkReports ON WorkReports FOR UPDATE
AS
INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'DeleteAsPartOfUpdate'
      FROM deleted

INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'InsertAsPartOfUpdate'
      FROM inserted
GO

--DELETE FROM WorkReports
--GO

--DELETE FROM WorkReportsLogs
--GO

/*30.
Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the other tables. 
In the end roll back the transaction.
*/
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
GO

BEGIN TRANSACTION

DELETE Employees 
  FROM Employees
  JOIN Departments
    ON Employees.DepartmentID = Departments.DepartmentID
   AND Departments.Name = 'Sales'

ROLLBACK TRANSACTION

/*31.
Start a database transaction and drop the table EmployeesProjects. Now how can you restore back the lost table data?
*/
USE TelerikAcademy

BEGIN TRANSACTION

DROP TABLE EmployeesProjects

ROLLBACK TRANSACTION

/*
32.
Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects 
and restore them back after dropping and re-creating the table.
*/
USE TelerikAcademy

SET NOCOUNT ON

BEGIN TRANSACTION

DECLARE @employeesProjects TABLE(
	EmployeeID int,
	ProjectID int
)

INSERT INTO @employeesProjects (EmployeeID, ProjectID)
SELECT EmployeeID,
	   ProjectID
  FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
  EmployeeID int NOT NULL,
  ProjectID int NOT NULL,
  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
SELECT EmployeeID,
	   ProjectID
  FROM @employeesProjects

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID)

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY(ProjectID)
REFERENCES Projects(ProjectID)
GO

COMMIT TRANSACTION