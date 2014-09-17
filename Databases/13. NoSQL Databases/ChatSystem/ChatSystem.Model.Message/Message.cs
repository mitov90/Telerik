namespace ChatSystem.Model.Message
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string User { get; set; }

        public string MessageText { get; set; }

        public DateTime Time { get; set; }
    }
}