namespace ToyStore.Console.Client
{
    using System.Linq;

    using ToyStore.Data;
    using ToyStore.DataSeed;
    using ToyStore.DataSeed.Contracts;

    internal class EntryPoint
    {
        private static readonly ToysStoreEntities ToyStoreDbContext;

        private static readonly ILogger Logger;
        
        static EntryPoint()
        {
            ToyStoreDbContext = new ToysStoreEntities();
            Logger = new ConsoleLogger();
        }

        private static void Main()
        {
            using (ToyStoreDbContext)
            {
                if (!ToyStoreDbContext.Toys.Any())
                {
                    DataSeed seeder = new DataSeed(ToyStoreDbContext, Logger);
                    seeder.Seed();
                }
            }
        }
    }
}