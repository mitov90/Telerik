namespace BloggingSystem.Services.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "tag")]
    public class TagDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int PostsCount { get; set; }
    }
}