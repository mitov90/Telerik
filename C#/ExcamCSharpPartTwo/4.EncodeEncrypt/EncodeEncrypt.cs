using System;
using System.Text;

class EncodeEncrypt
{
    static void Main()
    {
        var message = Console.ReadLine();
        var cypher = Console.ReadLine();
        var lengthOfCypher = cypher.Length;

        Console.WriteLine(Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher);
    }

    private static string Encrypt(string message, string cypher)
    {
        var cypherLength = cypher.Length;
        var messageLength = message.Length;
        var maxLength = Math.Max(cypherLength, messageLength);

        var result = new StringBuilder(message);

        for (int curIndex = 0; curIndex < maxLength; curIndex++)
        {
            var cypherChar = cypher[curIndex % cypherLength] - 'A';
            var messageChar = result[curIndex % messageLength] - 'A';

            result[curIndex % messageLength] = (char)((cypherChar ^ messageChar) + 'A');
        }

        return result.ToString();
    }

   private static string Encode(string str)
   {
       var result = new StringBuilder();
       char previous = str[0];
       int counter = 1;

       for (int i = 1; i < str.Length; i++)
       {
           if (str[i] == previous)
           {
               counter++;
           }
           else
           {
               PutEncoded(counter, result, previous);
               previous = str[i];
               counter = 1;
           }

       }
       PutEncoded(counter,result,previous);
       return result.ToString();
   }

    private static void PutEncoded(int counter, StringBuilder result, char previous)
    {
        if (counter > 2)
        {
            result.Append(counter);
            result.Append(previous);
        }
        else
        {
            result.Append(new string(previous, counter));
        }
    }
}
