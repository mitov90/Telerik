--2.	Get all departments and how many 
--employees there are in each one. Sort 
--the result by the number of employees in descending order.

SELECT d.name AS [Department name],
COUNT(e.id) AS [Employees count]
FROM dbo.Employees e
INNER JOIN dbo.Departments d
ON e.departmentId =d.id
GROUP BY d.name
ORDER BY [Employees count] DESC