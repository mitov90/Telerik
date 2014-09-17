namespace RemoveItemsThatOccurOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RemoveItemsThatOccurOddNumberOfTimes
    {
        private static List<T> GetItemsThatOccurEvenNumberOfTimes<T>(
            IReadOnlyCollection<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "source cannot be null.");
            }

            if (source.Count == 0)
            {
                throw new ArgumentException("Sequence contains no elements.", "source");
            }

            var countConcurrences = new Dictionary<T, int>();

            foreach (var item in source)
            {
                if (countConcurrences.ContainsKey(item))
                {
                    countConcurrences[item]++;
                }
                else
                {
                    countConcurrences[item] = 1;
                }
            }

            return source.Where(item => countConcurrences[item] % 2 == 0).ToList();
        }

        private static void Main()
        {
            var numbers = new List<int>(new[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 });

            var itemsThatOccurEvenNumberOfTimes = GetItemsThatOccurEvenNumberOfTimes(numbers);

            Console.WriteLine(
                "The list with the items that occur odd number of times removed: {0}.",
                string.Join(", ", itemsThatOccurEvenNumberOfTimes));
        }
    }
}
