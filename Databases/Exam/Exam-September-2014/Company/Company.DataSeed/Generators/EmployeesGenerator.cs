namespace Company.DataSeed.Generators
{
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.DataSeed.Contracts;

    public class EmployeesGenerator : Generator, IGenerator
    {
        public EmployeesGenerator(CompanyEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            List<int> departmentsIds = this.db.Departments.Select(d => d.id).ToList();
            List<int> employeeIds = this.db.Employees.Select(e => e.id).ToList();

            this.logger.Log("Adding employees\n");
            for (int i = 0; i < this.count; i++)
            {
                Employee newEmployee = new Employee
                                           {
                                               departmentId =
                                                   departmentsIds[
                                                       this.random.GetRandomNumber(0, departmentsIds.Count - 1)
                                                   ], 
                                               firstName = this.random.GetRandomLengthString(5, 20), 
                                               lastName = this.random.GetRandomLengthString(5, 20), 
                                               yearSalary = this.random.GetRandomNumber(6000, 1000000), 
                                               managerId =
                                                   (this.random.GetChance(30) && employeeIds.Any())
                                                       ? employeeIds[
                                                           this.random.GetRandomNumber(
                                                               0, 
                                                               employeeIds.Count - 1)]
                                                       : (int?)null
                                           };
                this.db.Employees.Add(newEmployee);
                if (i % 100 == 0)
                {
                    this.logger.Log(".");
                    this.db.SaveChanges();
                }
            }

            this.logger.Log("\nAdded employees\n");
        }
    }
}