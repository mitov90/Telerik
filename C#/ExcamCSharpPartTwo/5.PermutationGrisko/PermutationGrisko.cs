using System;
using System.Diagnostics;

namespace _5.PermutationGrisko
{
    internal class PermutationGrisko
    {
        public static int Counter = 0;

        private static void Main()
        {
            string input = Console.ReadLine();
            int length = input.Length;
            var items = new int[length];

            for (int i = 0; i < length; i++)
            {
                items[i] = input[i];
            }
            Array.Sort(items);


            GriskoTest(length, items);

            while (NextPermutation(items))
            {
                GriskoTest(length, items);
            }

            Console.WriteLine(Counter);
        }

        private static bool GriskoTest(int length, int[] items)
        {
            bool duplicate = false;

            for (int i = 1; i < length; i++)
            {
                if (items[i] == items[i - 1])
                {
                    duplicate = true;
                    break;
                }
            }

            if (!duplicate) Counter++;
            return duplicate;
        }


        private static bool NextPermutation(int[] numList)
        {
            /*
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
         */

            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0) return false;

            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }

            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;

            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }

            return true;
        }
    }
}
