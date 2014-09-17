using System;
using System.Collections.Generic;
using System.Linq;

internal class FilterElementsThatOccurOddNumberOfTimes
{
    private static IList<T> GetItemsThatOccurOddNumberOfTimes<T>(T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "array cannot be null.");
        }

        Dictionary<T, int> occurrences = new Dictionary<T, int>();

        foreach (T item in array)
        {
            if (!occurrences.ContainsKey(item))
            {
                occurrences[item] = 1;
            }
            else
            {
                occurrences[item]++;
            }
        }

        return (from occurrence in occurrences 
                where occurrence.Value % 2 == 1
                select occurrence.Key)
                .ToList();
    }

    private static void Main()
    {
        string[] languages = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        IList<string> filteredLanguages = GetItemsThatOccurOddNumberOfTimes(languages);

        Console.WriteLine("Items that occur odd number of times: {0}.", string.Join(", ", filteredLanguages));
    }
}
