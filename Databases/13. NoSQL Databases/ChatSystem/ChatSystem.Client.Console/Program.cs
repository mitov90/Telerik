namespace ChatSystem.Client.Console
{
    using System;

    using ChatSystem.Data.MessageManager;

    internal class Program
    {
        private static void Main()
        {
            var mm = new MessageManager();
            var messages = mm.GetMessages(new DateTime(1990, 1, 1));

            Console.WriteLine(messages);
        }
    }
}