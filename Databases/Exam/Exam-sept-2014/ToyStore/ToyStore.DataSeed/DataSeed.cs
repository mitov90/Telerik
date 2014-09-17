namespace ToyStore.DataSeed
{
    using System.Collections.Generic;

    using ToyStore.Data;
    using ToyStore.DataSeed.Contracts;
    using ToyStore.DataSeed.Generators;

    public class DataSeed
    {
        private const int CategoriesCount = 100;

        private const int ManufacturersCount = 50;

        private const int AgeRangesCount = 50;

        private const int ToysCount = 20000;

        private readonly ToysStoreEntities db;

        private readonly ILogger logger;

        public DataSeed(ToysStoreEntities db, ILogger logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public void Seed()
        {
            this.db.Configuration.AutoDetectChangesEnabled = false;

            List<IGenerator> generators = new List<IGenerator>
                                              {
                                                  new CategoriesGenerator(
                                                      this.db, 
                                                      this.logger, 
                                                      CategoriesCount), 
                                                  new ManufacturersGenerator(
                                                      this.db, 
                                                      this.logger, 
                                                      ManufacturersCount), 
                                                  new AgeRangesGenerator(
                                                      this.db, 
                                                      this.logger, 
                                                      AgeRangesCount), 
                                                  new ToysGenerator(this.db, this.logger, ToysCount)
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