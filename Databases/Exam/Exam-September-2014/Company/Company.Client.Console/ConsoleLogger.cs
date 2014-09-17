namespace Company.Client.Console
{
    using System;

    using Company.DataSeed.Contracts;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.Write(message);
        }
    }
}