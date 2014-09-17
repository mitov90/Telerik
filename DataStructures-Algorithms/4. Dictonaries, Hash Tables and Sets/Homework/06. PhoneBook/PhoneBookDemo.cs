namespace PhoneBook
{
    using System;
    using System.IO;
    using System.Text;

    internal class PhoneBookDemo
    {
        private static void Main()
        {
            const string PhoneBookFilePath = "../../Resources/phones.txt";
            const string CommandsFilePath = "../../Resources/commands.txt";

            IEntriesManager entriesManager = new PhoneBookManager(PhoneBookFilePath);
            var commandProcessor = new CommandProcessor(entriesManager);

            using (var reader = new StreamReader(CommandsFilePath))
            {
                string line;

                var result = new StringBuilder();

                while ((line = reader.ReadLine()) != null)
                {
                    var command = Command.Parse(line);
                    var output = commandProcessor.Process(command);
                    result.Append(output);
                }

                Console.Write(result);
            }
        }
    }
}