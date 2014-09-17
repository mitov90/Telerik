namespace Company.DataSeed
{
    using System.Collections.Generic;

    using Company.Data;
    using Company.DataSeed.Contracts;
    using Company.DataSeed.Generators;

    public class DataSeed
    {
        private const int DepartmentsCount = 100;

        private const int ReportsCount = 250000;

        private const int ProjectsCount = 1000;

        private const int EmployeesCount = 5000;

        private readonly CompanyEntities db;

        private readonly ILogger logger;

        public DataSeed(CompanyEntities db, ILogger logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public void Seed()
        {
            this.db.Configuration.AutoDetectChangesEnabled = false;

            List<IGenerator> generators = new List<IGenerator>
                                              {
                                                  new DepartmentsGenerator(
                                                      this.db, 
                                                      this.logger, 
                                                      DepartmentsCount), 
                                                  new EmployeesGenerator(
                                                      this.db, 
                                                      this.logger, 
                                                      EmployeesCount), 
                                                  new ProjectsGenerator(
                                                      this.db, 
                                                      this.logger, 
                                                      ProjectsCount), 
                                                  new ReportsGenerator(
                                                      this.db, 
                                                      this.logger, 
                                                      ReportsCount), 
                                              };
            foreach (var generator in generators)
            {
                generator.Generate();
                this.db.SaveChanges();
            }

            this.db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}