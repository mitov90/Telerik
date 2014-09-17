namespace Company.DataSeed.Generators
{
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.DataSeed.Contracts;

    internal class ReportsGenerator : Generator, IGenerator
    {
        public ReportsGenerator(CompanyEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            List<int> employeesIds = this.db.Employees.Select(e => e.id).ToList();

            this.logger.Log("Adding reports (need 8 rows of dots)\n");

            for (int i = 0; i < this.count; i++)
            {
                Report newReport = new Report
                                       {
                                           time = this.random.GetRandomDate(), 
                                           employeeId =
                                               employeesIds[this.random.GetRandomNumber(0, employeesIds.Count - 1)]
                                       };

                this.db.Reports.Add(newReport);

                if (i % 100 == 0)
                {
                    this.db.SaveChanges();
                    this.db = new CompanyEntities();
                }

                if (i % 400 == 0)
                {
                    this.logger.Log(".");
                }
            }

            this.logger.Log("\nReports addded\n");
        }
    }
}