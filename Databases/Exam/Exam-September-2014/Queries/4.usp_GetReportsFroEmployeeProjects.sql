CREATE  PROC dbo.usp_GetReportsFroEmployeeProjects
AS
    BEGIN
        DELETE  FROM dbo.tmpTable
        INSERT  INTO tmpTable
                ( [Full Name] ,
                  [Project name] ,
                  [Department name] ,
                  [startDate] ,
                  [endDate] ,
                  [Reports]
                )
                SELECT  e.firstName + ' ' + e.lastName ,
                        p.name ,
                        d.name ,
                        ep.startDate ,
                        ep.endDate ,
                        result.Reports
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

    END
GO

EXEC dbo.usp_GetReportsFroEmployeeProjects