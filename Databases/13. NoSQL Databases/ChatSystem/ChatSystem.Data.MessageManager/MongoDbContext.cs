namespace ChatSystem.Data.MessageManager
{
    using ChatSystem.Model.Message;

    using MongoDB.Driver;

    public class MongoDbContext
    {
        private readonly string connectionString;

        private readonly string databaseName;

        private MongoServer mongoServer;

        public MongoDbContext()
            : this(Settings.Default.databaseName, Settings.Default.connectionString)
        {
        }

        public MongoDbContext(string databaseName, string connectionString)
        {
            this.databaseName = databaseName;
            this.connectionString = connectionString;
        }

        public MongoCollection<Message> GetMessageCollection
        {
            get
            {
                return this.GetCollection<Message>("Messages");
            }
        }

        public MongoCollection<UserSession> Users
        {
            get
            {
                return this.GetCollection<UserSession>("Users");
            }
        } 

        private MongoCollection<T> GetCollection<T>(string collectionName)
        {
            return this.GetDatabase().GetCollection<T>(collectionName);
        }

        private MongoDatabase GetDatabase()
        {
            if (this.mongoServer == null)
            {
                var mongoClient = new MongoClient(this.connectionString);
                this.mongoServer = mongoClient.GetServer();
            }

                return this.mongoServer.GetDatabase(this.databaseName);
        }
    }
}
