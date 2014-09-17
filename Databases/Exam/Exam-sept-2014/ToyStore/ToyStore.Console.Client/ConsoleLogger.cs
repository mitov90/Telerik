namespace ToyStore.Console.Client
{
    using System;

    using ToyStore.DataSeed.Contracts;

    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.Write(message);
        }
    }
}