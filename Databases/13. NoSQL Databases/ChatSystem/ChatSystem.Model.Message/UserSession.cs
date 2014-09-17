namespace ChatSystem.Model.Message
{
    using System;

    public class UserSession
    {
        public UserSession(string username)
        {
            this.Username = username;
        }

        public string Username { get; set; }

        public string Name { get; set; }

        public DateTime LoggedOn { get; set; }
    }
}