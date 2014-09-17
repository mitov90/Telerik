namespace CarSystem.Client.Console
{
    using System;
    using System.Linq;
    using System.Text;

    using CarSystem.Data;
    using CarSystem.JSON;
    using CarSystem.Query.Processor;

    internal class EntryPointConsole
    {
        private static readonly CarDbContext DbContext = new CarDbContext();

        private static void Main()
        {
            // Make sure read all info
            Console.OutputEncoding = Encoding.Unicode;
            using (DbContext)
            {
                if (!DbContext.Cars.Any())
                {
                    Importer importer = new Importer(DbContext);
                    importer.Import(@"../../../Data.Json.Files");
                    DbContext.SaveChanges();
                }

                QueryProcessor queryProcessor = new QueryProcessor(DbContext);
                queryProcessor.ReadXmlQueries(@"../../../Queries.xml");
            }
        }
    }
}