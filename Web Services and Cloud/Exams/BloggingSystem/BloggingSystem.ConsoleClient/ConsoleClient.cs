namespace BloggingSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using BloggingSystem.Data;

    internal class ConsoleClient
    {
        private static void Main()
        {
            // Run the console client first in order to create the database
            Database.SetInitializer(new DatabaseInitializer());

            using (var dbContext = new BloggingSystemContext())
            {
                dbContext.Database.Initialize(true);
                Console.WriteLine(dbContext.Users.Count());
            }
        }
    }
}