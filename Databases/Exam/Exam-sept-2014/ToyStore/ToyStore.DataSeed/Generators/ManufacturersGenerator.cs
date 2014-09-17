namespace ToyStore.DataSeed.Generators
{
    using ToyStore.Data;
    using ToyStore.DataSeed.Abstract;
    using ToyStore.DataSeed.Contracts;

    internal class ManufacturersGenerator : Generator
    {
        public ManufacturersGenerator(ToysStoreEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            this.logger.Log("Adding manufacturers\n");
            for (int i = 0; i < this.count; i++)
            {
                Manufacturer newManufacturer = new Manufacturer
                                                   {
                                                       country = this.random.GetRandomLengthString(2, 30), 
                                                       name = this.random.GetRandomLengthString(3, 50), 
                                                   };
                this.db.Manufacturers.Add(newManufacturer);

                if (this.count % 100 == 0)
                {
                    this.logger.Log(".");
                    this.SaveChanges();
                }
            }

            this.logger.Log("Manufacturers added");
        }
    }
}