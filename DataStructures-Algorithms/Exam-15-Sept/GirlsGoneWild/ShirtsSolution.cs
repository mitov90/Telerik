﻿namespace GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShirtsSolution
    {
        private static readonly SortedSet<string> Results = new SortedSet<string>();

        private static readonly List<List<int>> CombinationsOfPeople = new List<List<int>>();

        private static readonly List<List<char>> CombinationsOfShirts = new List<List<char>>();

        private static int[] combinations;

        private static int numberOfPeople;

        private static char[] shirtTypes;

        public static void Main()
        {
            combinations = new int[int.Parse(Console.ReadLine())];
            shirtTypes = Console.ReadLine().ToCharArray().OrderBy(x => x).ToArray();
            numberOfPeople = int.Parse(Console.ReadLine());

            Comb(0, 0, combinations, x => CombinationsOfPeople.Add(new List<int>(x)));
            combinations = new int[shirtTypes.Length];
            Comb(0, 0, combinations, x => {
                                             List<char> list = new List<char>();
                                             for (int i = 0; i < numberOfPeople; i++)
                                             {
                                                 list.Add(shirtTypes[x[i]]);
                                             }

                                             CombinationsOfShirts.Add(list);
                                         });

            foreach (var combinationOfPeople in CombinationsOfPeople)
            {
                foreach (var combinationOfShirt in CombinationsOfShirts)
                {
                    List<char> permutationsOfShirts = new List<char>(combinationOfShirt);
                    PermuteRep(
                               permutationsOfShirts, 
                               0, 
                               permutationsOfShirts.Count, 
                               x => MergeResult(combinationOfPeople, x));
                }
            }

            StringBuilder output = new StringBuilder();
            output.AppendLine(Results.Count.ToString());
            foreach (string result in Results)
            {
                output.AppendLine(result);
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static void Comb(int index, int start, int[] array, Action<int[]> action)
        {
            if (index >= numberOfPeople)
            {
                action(array);
            }
            else
            {
                for (int i = start; i < array.Length; i++)
                {
                    array[index] = i;
                    Comb(index + 1, i + 1, array, action);
                }
            }
        }

        private static void PermuteRep(List<char> arr, int start, int n, Action<List<char>> action)
        {
            action(arr);
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        char oldFirst = arr[left];
                        arr[left] = arr[right];
                        arr[right] = oldFirst;

                        PermuteRep(arr, left + 1, n, action);
                    }
                }

                char firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstElement;
            }
        }

        private static void MergeResult(IReadOnlyList<int> numbers, IReadOnlyList<char> symbols)
        {
            StringBuilder result = new StringBuilder(numbers.Count + symbols.Count);

            for (int i = 0; i < symbols.Count; i++)
            {
                result.Append(numbers[i]);
                result.Append(symbols[i]);
                result.Append('-');
            }

            result.Length--;

            Results.Add(result.ToString());
        }
    }
}