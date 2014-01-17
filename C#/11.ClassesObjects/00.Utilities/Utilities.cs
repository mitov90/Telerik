using System;

public class Utilities
{
    public static int InputInteger(string text)
    {
        int value;
        do
        {
            Console.Write(text);
        }
        while ( !int.TryParse(Console.ReadLine(), out value) );
        return value;
    }
    
}