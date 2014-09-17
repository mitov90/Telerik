--1.	Get the full name (first name + “ “ + last name)  
--of every employee and its salary, for each employee with 
--salary between $100 000 and $150 000, inclusive. Sort the
-- results by salary in ascending order.

SELECT e.firstName + ' ' + e.lastName AS [Full Name],
e.yearSalary AS [Year Salary]
FROM dbo.Employees e
WHERE e.yearSalary BETWEEN 100000 AND 150000
ORDER BY e.yearSalary