using System;

class SqaureRoot
{
    static double Sqrt(int value)
    {
        if ( value < 0 )
            throw new Exception("Invalid number");
        return Math.Sqrt(value);
    }
    static void Main()
    {
        try
        {
            int value;
            if ( !int.TryParse(Console.ReadLine(), out value) )
            {
                throw new ArgumentException("Invalid number");
            }
            Console.WriteLine(Math.Sqrt(value));
        }
        catch ( FormatException fex )
        {
            Console.WriteLine(fex.Message);
        }
        catch ( OverflowException oex )
        {
            Console.WriteLine(oex.Message);
        }
        catch ( ArgumentOutOfRangeException aex )
        {
            Console.WriteLine(aex.Message);
        }
        catch ( Exception e )
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }

    }
}
