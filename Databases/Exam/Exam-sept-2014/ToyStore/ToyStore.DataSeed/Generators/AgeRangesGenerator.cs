namespace ToyStore.DataSeed.Generators
{
    using ToyStore.Data;
    using ToyStore.DataSeed.Abstract;
    using ToyStore.DataSeed.Contracts;

    public class AgeRangesGenerator : Generator
    {
        public AgeRangesGenerator(ToysStoreEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            this.logger.Log("Adding age ranges\n");
            for (int i = 0; i < this.count; i++)
            {
                int minAge = this.random.GetRandomNumber(1, 10);
                int maxAge = this.random.GetRandomNumber(minAge, 30);
                AgeRanx newRange = new AgeRanx { minAge = minAge, maxAge = maxAge };

                this.db.AgeRanges.Add(newRange);

                if (i % 100 == 0)
                {
                    this.logger.Log(".");
                    this.SaveChanges();
                }
            }

            this.logger.Log("\nAge ranges added");
        }
    }
}