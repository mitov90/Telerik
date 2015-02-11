namespace BloggingSystem.Services.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "user")]
    public class UserDto
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }
    }
}