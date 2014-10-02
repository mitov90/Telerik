namespace PhoneBook
{
    using System;

    public class Command
    {
        public Command(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; private set; }

        public string[] Arguments { get; private set; }

        public static Command Parse(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "value cannot be null.");
            }

            var openingParenthesisIndex = value.IndexOf('(');

            if (openingParenthesisIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + value, "value");
            }

            var name = value.Substring(0, openingParenthesisIndex).Trim();

            var closingParenthesisIndex = value.IndexOf(')');

            if (closingParenthesisIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + value, "value");
            }

            var argumentsList =
                value.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1)
                    .Trim();

            var arguments = argumentsList.Split(new[] { ',' });

            for (var i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            var command = new Command(name, arguments);
            return command;
        }
    }
}