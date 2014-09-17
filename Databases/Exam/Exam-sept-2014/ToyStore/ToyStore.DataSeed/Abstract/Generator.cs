namespace ToyStore.DataSeed.Abstract
{
    using ToyStore.Data;
    using ToyStore.DataSeed.Contracts;

    public abstract class Generator : IGenerator
    {
        protected ToysStoreEntities db;

        protected ILogger logger;

        protected RandomGenerator random;

        protected int count;

        protected Generator(ToysStoreEntities db, ILogger logger, int seedCount)
        {
            this.random = RandomGenerator.GetInstance();
            this.logger = logger;
            this.db = db;
            this.count = seedCount;
        }

        public abstract void Generate();

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }
    }
}