using System;
using System.Collections.Generic;

class Neurons
{
    static void Main()
    {
        List<char[]> neurons = new List<char[]>();
        inputNeurons(neurons);

        for ( int i = 0; i < neurons.Count; i++ )
        {
            int firstIndex = Array.IndexOf(neurons[i], '1');
            int lastIndex = Array.LastIndexOf(neurons[i], '1');
            if ( firstIndex == -1 )
                continue;
            for ( int j = firstIndex; j <= lastIndex; j++ )
            {
                neurons[i][j] = neurons[i][j] == '1' ? '0' : '1';
            }
        }

        foreach ( var charArray in neurons )
        {
            //Console.WriteLine(charArray);
            Console.WriteLine(Convert.ToUInt32(new string(charArray), 2));
        }

    }

    private static void inputNeurons(List<char[]> neurons)
    {
        uint tempNum;
        while ( uint.TryParse(Console.ReadLine(), out tempNum) )
        {
            neurons.Add(Convert.ToString(tempNum, 2).PadLeft(32, '0').ToCharArray());
        }
    }
}
