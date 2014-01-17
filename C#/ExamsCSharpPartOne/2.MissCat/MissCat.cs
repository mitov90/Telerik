using System;

class MissCat
{
    static void Main()
    {
        int[] catNumber = new int[11];
        int numCat = int.Parse(Console.ReadLine());
        for ( int i = 0; i < numCat; i++ )
        {
            catNumber[int.Parse(Console.ReadLine())]++;
        }
        int maxVotes = 0;
        int indexCat = 0;
        for ( int i = 0; i < catNumber.Length; i++ )
        {
            if (catNumber[i]>maxVotes)
            {
                maxVotes = catNumber[i];
                indexCat = i;
            }
        }
        Console.WriteLine(indexCat);

    }
}
