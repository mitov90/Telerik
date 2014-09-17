namespace Company.Client.Console
{
    using System.Linq;

    using Company.Data;
    using Company.DataSeed;
    using Company.DataSeed.Contracts;

    internal class EntryPoint
    {
        private static readonly CompanyEntities CompanyDbContext;

        private static readonly ILogger Logger;

        static EntryPoint()
        {
            CompanyDbContext = new CompanyEntities();
            Logger = new ConsoleLogger();
        }

        private static void Main()
        {
            using (CompanyDbContext)
            {
                //if (!CompanyDbContext.Employees.Any())
                {
                    DataSeed seeder = new DataSeed(CompanyDbContext, Logger);
                    seeder.Seed();
                }
            }
        }
    }
}