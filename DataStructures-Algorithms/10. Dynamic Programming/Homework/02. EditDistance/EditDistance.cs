using System;

internal class EditDistance
{
    public enum Operation
    {
        Skip = 0, 

        Delete = 1, 

        Insert = 2, 

        Replace = 3
    }

    // Function receives the following parameters as input:
    // b[i, j] which is the back pointers array
    // S1 and S2 which are the input strings
    // i is the index at which the substring ends in the first string
    // j is the index at which the substring ends in the second string
    // This function should be initially called as 
    // PrintSteps(b, S1, S2, m, n) so that it would print all the needed 
    // steps to convert S1 into S2
    private static void PrintSteps(Operation[,] b, string s1, string s2, int i, int j)
    {
        // Base case, do nothing as the solution will be
        // trivial. It is either (j) insertions or (i) deletions
        if (i <= 0 && j <= 0)
        {
            return;
        }

        // Deleting the character at position (i)
        if (b[i, j] == Operation.Delete)
        {
            PrintSteps(b, s1, s2, i - 1, j);
            Console.WriteLine("Delete character '{0}' at position {1} from the first string.", s1[i], i);
        }
        else if (b[i, j] == Operation.Insert)
        {
            // Inserting a character at position (i)
            PrintSteps(b, s1, s2, i, j - 1);
            Console.WriteLine(
                "Insert character '{0}' from the second string at position {1}"
                + " into the first string at position {2}.", 
                s2[j], 
                j, 
                i);
        }
        else if (b[i, j] == Operation.Replace)
        {
            // Replacing a character at position (i)
            PrintSteps(b, s1, s2, i - 1, j - 1);
            Console.WriteLine(
                "Replace character '{0}' at position {1} in the first string"
                + " with character '{2}' at position {3} in the second string.", 
                s1[i], 
                i, 
                s2[j], 
                j);
        }
        else
        {
            // No operation is needed
            PrintSteps(b, s1, s2, i - 1, j - 1);
        }
    }

    /// <summary>
    ///     Uses the algorithm described at
    ///     http://www.8bitavenue.com/2011/12/dynamic-programming-edit-distance/
    /// </summary>
    /// <param name="word1">
    /// </param>
    /// <param name="word2">
    /// </param>
    /// <param name="cd">
    /// </param>
    /// <param name="ci">
    /// </param>
    /// <param name="cr">
    /// </param>
    private static void FindLevensteinDistance(string word1, string word2, double cd, double ci, double cr)
    {
        int m = word1.Length;
        int n = word2.Length;

        string s1 = "_" + word1;
        string s2 = "_" + word2;

        double[,] matrix = new double[m + 1, n + 1];
        Operation[,] operations = new Operation[m + 1, n + 1];

        // If the first string is empty then 
        // we need (j) insert operations to 
        // convert the first string into the second string
        for (int j = 0; j <= n; j++)
        {
            matrix[0, j] = j * ci;
            operations[0, j] = Operation.Insert;
        }

        // If the second string is empty then 
        // we need (i) delete operations to 
        // convert the first string into empty string
        for (int i = 0; i <= m; i++)
        {
            matrix[i, 0] = i * cd;
            operations[i, 0] = Operation.Delete;
        }

        // For each substring in the first 
        // string ending at position (i)
        for (int i = 1; i <= m; i++)
        {
            // For each substring in the second string
            // ending at position (j)
            for (int j = 1; j <= n; j++)
            {
                // If the last characters in each substring 
                // are equal, then no operation is needed
                if (s1[i] == s2[j])
                {
                    matrix[i, j] = matrix[i - 1, j - 1];
                    operations[i, j] = Operation.Skip;
                }
                else
                {
                    // Otherwise we take the minimum of three cases
                    // Case 1: deleting last character in 
                    // the first substring ending at position (i)
                    double min = cd + matrix[i - 1, j];
                    operations[i, j] = Operation.Delete;

                    // Case 2: Inserting the last character from 
                    // the second substring at position (j) 
                    // into the first substring ending at position (i)
                    if (ci + matrix[i, j - 1] < min)
                    {
                        min = ci + matrix[i, j - 1];
                        operations[i, j] = Operation.Insert;
                    }

                    // Case 3: Replacing the last character in 
                    // the first substring at position (i) with 
                    // the last character in the second substring 
                    // at position (j) 
                    if (cr + matrix[i - 1, j - 1] < min)
                    {
                        min = cr + matrix[i - 1, j - 1];
                        operations[i, j] = Operation.Replace;
                    }

                    // Save the minimum value
                    matrix[i, j] = min;
                }
            }
        }

        Console.WriteLine("Total cost: " + matrix[m, n]);
        PrintSteps(operations, s1, s2, m, n);
    }

    private static void Main()
    {
        FindLevensteinDistance("developer", "enveloped", 0.9, 0.8, 1);

        // FindLevensteinDistance("Format", "Forest", 1, 1, 1);
        // FindLevensteinDistance("abracadabra", "mabragabra", 1, 2, 3);
    }
}