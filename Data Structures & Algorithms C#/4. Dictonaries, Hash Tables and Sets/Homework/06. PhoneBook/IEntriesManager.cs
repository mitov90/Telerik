namespace PhoneBook
{
    using System.Collections.Generic;

    public interface IEntriesManager
    {
        bool TryGetEntries(string name, out List<string> entries);

        bool TryGetEntries(string name, string location, out List<string> entries);
    }
}