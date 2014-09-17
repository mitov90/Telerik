﻿namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommandProcessor
    {
        private readonly IEntriesManager entriesManager;

        public CommandProcessor(IEntriesManager entriesManager)
        {
            this.entriesManager = entriesManager;
        }

        public IEntriesManager EntriesManager
        {
            get
            {
                return this.entriesManager;
            }
        }

        public string Process(Command command)
        {
            switch (command.Name)
            {
                case "find":
                    {
                        return this.ListEntries(command.Arguments);
                    }

                default:
                    {
                        throw new ArgumentException("Invalid command: " + command.Name, "command");
                    }
            }
        }

        private string ListEntries(IList<string> arguments)
        {
            bool success;
            List<string> entries;

            if (arguments.Count == 1)
            {
                success = this.entriesManager.TryGetEntries(arguments[0], out entries);
            }
            else if (arguments.Count == 2)
            {
                success = this.entriesManager.TryGetEntries(arguments[0], arguments[1], out entries);
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments.", "arguments");
            }

            if (success)
            {
                var output = new StringBuilder();

                foreach (var entry in entries)
                {
                    output.AppendLine(entry);
                }

                return output.ToString();
            }

            return string.Format("Not found!{0}", Environment.NewLine);
        }
    }
}