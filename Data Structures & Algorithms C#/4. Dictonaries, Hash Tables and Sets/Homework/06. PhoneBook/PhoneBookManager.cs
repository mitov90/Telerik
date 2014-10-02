namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PhoneBookManager : IEntriesManager
    {
        private readonly Dictionary<string, List<string>> phoneBook = new Dictionary<string, List<string>>();

        public PhoneBookManager(string dataFilePath)
        {
            this.ReadData(dataFilePath);
        }

        public bool TryGetEntries(string name, out List<string> entries)
        {
            return this.phoneBook.TryGetValue(name.ToLower(), out entries);
        }

        public bool TryGetEntries(string name, string location, out List<string> entries)
        {
            return this.TryGetEntries(Combine(name, location), out entries);
        }

        private static string Combine(string value1, string value2)
        {
            return string.Format("{0}@{1}", value1, value2);
        }

        private void ReadData(string path)
        {
            using (var reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var recordData = line.Split('|');
                    var personNames = recordData[0].Trim();
                    var location = recordData[1].Trim();

                    var names = personNames.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var name in names)
                    {
                        this.AddToPhoneBook(name, line);
                        var nameAndLocation = Combine(name, location);
                        this.AddToPhoneBook(nameAndLocation, line);
                    }
                }
            }
        }

        private void AddToPhoneBook(string key, string entry)
        {
            key = key.ToLower();
            List<string> entries;

            if (!this.phoneBook.TryGetValue(key, out entries))
            {
                entries = new List<string>();
                this.phoneBook.Add(key, entries);
            }

            entries.Add(entry);
        }


    }
}