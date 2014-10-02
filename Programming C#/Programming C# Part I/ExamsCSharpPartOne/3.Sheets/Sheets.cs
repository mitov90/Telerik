using System;

class Sheets
{
    static void Main()
    {
        const int numberSheets = 10;
        int[] sheets = new int[numberSheets+1];
     
        for ( int i = 0; i <= numberSheets; i++ )
        {
            sheets[numberSheets - i] = (int)Math.Pow(2, i);
        }

        int requestSheets = int.Parse(Console.ReadLine());

        for ( int i = 0; i <= numberSheets; i++ )
        {
            if (requestSheets/sheets[i] == 1)
            {
                requestSheets -= sheets[i];
                sheets[i] = 0;
            }
            else
            {
                Console.Write("A");
                Console.WriteLine(i);
            }
        }

    }
}
