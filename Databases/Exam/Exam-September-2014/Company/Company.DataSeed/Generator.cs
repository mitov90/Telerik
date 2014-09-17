namespace Company.DataSeed
{
    using Company.Data;
    using Company.DataSeed.Contracts;

    public abstract class Generator
    {
        protected CompanyEntities db;

        protected ILogger logger;

        protected RandomGenerator random;

        protected int count;

        protected Generator(CompanyEntities db, ILogger logger, int seedCount)
        {
            this.random = RandomGenerator.GetInstance();
            this.logger = logger;
            this.db = db;
            this.count = seedCount;
        }

        public abstract void Generate();

    }
}