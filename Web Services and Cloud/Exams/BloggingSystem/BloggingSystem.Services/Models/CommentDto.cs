namespace BloggingSystem.Services.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "comment")]
    public class CommentDto
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public string Author { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}