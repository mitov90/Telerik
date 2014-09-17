using System;
using System.Data.Entity;
using System.Linq;

using EntityFrameworkModels;

internal class EmployeeSelectorUsingEntityFramework
{
    private static void SelectEmployeesNoInclude()
    {
        using (var context = new TelerikAcademyEntities())
        {
            /*
            SELECT [t0].[EmployeeID], [t0].[FirstName], [t0].[LastName], [t0].[MiddleName], [t0].[JobTitle], [t0].[DepartmentID], [t0].[ManagerID], [t0].[HireDate], [t0].[Salary], [t0].[AddressID]
            FROM [Employees] AS [t0]
            GO

             -- A Lot of queries like this with diffrent parameters for every employee
            DECLARE @p0 Int = 7
            SELECT [t0].[DepartmentID], [t0].[Name], [t0].[ManagerID]
            FROM [Departments] AS [t0]
            WHERE [t0].[DepartmentID] = @p0
            */

            Console.WriteLine("Employees:");
            foreach (var employee in context.Employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nDepartment: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Department.Name,
                    employee.Address.Town.Name);
            }
        }
    }

    private static void SelectEmployeesWithInclude()
    {

        // Result sql query:
        // SELECT [t0].[EmployeeID], [t0].[FirstName], [t0].[LastName], [t0].[MiddleName],
        // [t0].[JobTitle], [t0].[DepartmentID], [t0].[ManagerID], [t0].[HireDate],
        // [t0].[Salary], [t0].[AddressID]
        // FROM [Employees] AS [t0]
        using (var context = new TelerikAcademyEntities())
        {
            var employees = context.Employees
                .Include(e => e.Department)
                .Include(e => e.Address.Town);

            foreach (var employee in employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nDepartment: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Department.Name,
                    employee.Address.Town.Name);
            }
        }
    }

    private static void SelectEmployeesUsingToList()
    {
        using (var context = new TelerikAcademyEntities())
        {
            /*
             * SELECT [t0].[EmployeeID], [t0].[FirstName], [t0].[LastName], [t0].[MiddleName], [t0].[JobTitle], [t0].[DepartmentID], [t0].[ManagerID], [t0].[HireDate], [t0].[Salary], [t0].[AddressID]
                FROM [Employees] AS [t0]
                GO
                
             * A lot of queries like this
                DECLARE @p0 Int = 166
                SELECT [t0].[AddressID], [t0].[AddressText], [t0].[TownID]
                FROM [Addresses] AS [t0]
                WHERE [t0].[AddressID] = @p0
                GO
             * */
            Console.WriteLine("Employees:");

            var employees = context.Employees.ToList()
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address.AddressText,
                    TownName = e.Address.Town.Name
                })
                .ToList()
                .Where(e => e.TownName == "Sofia")
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nAddress: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Address,
                    employee.TownName);
            }
        }
    }

    private static void SelectEmployeesUsingOptimization()
    {
        using (var context = new TelerikAcademyEntities())
        {
            /*
            DECLARE @p0 NVarChar(1000) = 'Sofia'
            SELECT [t0].[EmployeeID], [t0].[FirstName], [t0].[LastName], [t0].[MiddleName], [t0].[JobTitle], [t0].[DepartmentID], [t0].[ManagerID], [t0].[HireDate], [t0].[Salary], [t0].[AddressID]
            FROM [Employees] AS [t0]
            INNER JOIN [Addresses] AS [t1] ON [t0].[AddressID] = ([t1].[AddressID])
            INNER JOIN [Towns] AS [t2] ON [t1].[TownID] = ([t2].[TownID])
            WHERE [t2].[Name] = @p0
             */

            Console.WriteLine("Employees:");

            var employees =
                from employee in context.Employees
                join address in context.Addresses
                on employee.AddressID equals address.AddressID
                join town in context.Towns
                on address.TownID equals town.TownID
                where town.Name == "Sofia"
                select employee;

            foreach (var employee in employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nAddress: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Address.AddressText,
                    employee.Address.Town.Name);
            }
        }
    }

    private static void Main()
    {
        // SelectEmployeesNoInclude();
        SelectEmployeesWithInclude();
        // SelectEmployeesUsingToList();
        // SelectEmployeesUsingOptimization();
    }
}
