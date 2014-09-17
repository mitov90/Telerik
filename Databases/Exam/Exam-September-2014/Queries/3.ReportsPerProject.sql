--3.Get each employee’s full name (first name + “ “ + last name),
--  project’s name, department’s name, starting and ending date FOR
--  each employee in project. Additionally get the number of all 
--  reports, which time of reporting is between the start and 
--  end date. Sort the results first by the employee id, then by 
--  the project id.

SELECT  e.firstName + ' ' + e.lastName AS [Full Name] ,
        p.name AS [Project name] ,
        d.name AS [Department name] ,
        ep.startDate ,
        ep.endDate,
		[Reports]
FROM    dbo.Employees e
        INNER JOIN dbo.Departments d
            ON e.departmentId = d.id
        INNER JOIN dbo.EmployeesProjects ep
            ON ep.employeeId = e.id
        INNER JOIN dbo.Projects p
            ON p.id = ep.projectId
        INNER JOIN ( SELECT COUNT(r.id) AS [Reports] ,
                            ep.projectId AS [Project] ,
                            ep.employeeId AS [Employee]
                     FROM   dbo.EmployeesProjects ep
                            INNER JOIN dbo.Reports r
                                ON r.employeeId = ep.employeeId
                     WHERE  r.time BETWEEN ep.startDate AND ep.endDate
                     GROUP BY ep.projectId ,
                            ep.employeeId
                   ) result
            ON result.Employee = e.id
ORDER BY e.id ,
        p.id

