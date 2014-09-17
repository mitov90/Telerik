namespace ChatSystem.Data.MessageManager
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using ChatSystem.Model.Message;

    using MongoDB.Driver.Builders;

    public class MessageManager
    {
        private readonly MongoDbContext dbContext;

        private readonly StringBuilder messageBuilder;

        public MessageManager()
        {
            this.dbContext = new MongoDbContext();
            this.messageBuilder = new StringBuilder();
            this.BufferedMessages = 0;
        }

        public long BufferedMessages { get; private set; }

        public Task<bool> HaveNewPosts()
        {
            return Task.Run(() =>
            {
                var newPostCount = this.dbContext.GetMessageCollection.Count();

                var haveNewPosts = newPostCount != this.BufferedMessages;
                if (haveNewPosts)
                {
                    this.BufferedMessages = newPostCount;
                }

                return haveNewPosts;
            });
        }

        public void PostMessage(Message post)
        {
            this.dbContext.GetMessageCollection.Insert(post);
        }

        public string GetMessages(DateTime startDate)
        {
            this.GetAllMessages(startDate);
            return this.messageBuilder.ToString();
        }

        public string GenerateOnePostAsString(Message postModel)
        {
            var newMessage = this.FormatMessage(postModel);
            this.messageBuilder.AppendLine(newMessage);
            return newMessage;
        }

        private void GetAllMessages(DateTime startDate)
        {
            var getMessagesFromDate = Query<Message>.Where(m => m.Time >= startDate);
            var messagesCollection = this.dbContext.GetMessageCollection;
            var messages = messagesCollection.Find(getMessagesFromDate);
            this.BufferedMessages += messages.Count();

            foreach (var message in messages)
            {
                this.FormatMessage(message);
            }

            if (this.messageBuilder.Length >= 100)
            {
                // remove some messages;
            }
        }

        private string FormatMessage(Message message)
        {
            var formatDate = message.Time.ToLocalTime().ToString("t");
            var newMessage = string.Format("[{0}] {1}: {2}", formatDate, message.User, message.MessageText);
            this.messageBuilder.AppendLine(newMessage);
            return newMessage;
        }
    }
}
