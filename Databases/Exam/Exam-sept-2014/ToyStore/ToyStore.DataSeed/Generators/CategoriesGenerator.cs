namespace ToyStore.DataSeed.Generators
{
    using ToyStore.Data;
    using ToyStore.DataSeed.Abstract;
    using ToyStore.DataSeed.Contracts;

    internal class CategoriesGenerator : Generator
    {
        public CategoriesGenerator(ToysStoreEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            this.logger.Log("Adding categories\n");
            for (int i = 0; i < this.count; i++)
            {
                Category newCategory = new Category { name = this.random.GetRandomLengthString(3, 50) };

                this.db.Categories.Add(newCategory);

                if (this.count % 100 == 0)
                {
                    this.logger.Log(".");
                    this.SaveChanges();
                }
            }

            this.logger.Log("\nCategories addded");
        }
    }
}