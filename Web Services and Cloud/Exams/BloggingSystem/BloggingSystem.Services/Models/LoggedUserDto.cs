namespace BloggingSystem.Services.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "user")]
    public class LoggedUserDto
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}