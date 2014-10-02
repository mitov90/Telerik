using System;

class UserInputChoice
{
    static void Main()
    {
        string userInput;
        do
        {
            Console.Write("Enter input double, int or string: ");
            userInput = Console.ReadLine().ToLower();
        }
        while(!(userInput == "int" || userInput == "double" || userInput == "string"));

        switch ( userInput )
        {
            case "int":
                int num;
                do
                {
                    Console.Write("Enter your int:");
                } while ( !int.TryParse(Console.ReadLine(), out num) );
                Console.WriteLine("Your int +1: {0}", num+1);
                    break;
            case "double":
                    double numDouble;
                    do
                    {
                        Console.Write("Enter your double:");
                    } while ( !double.TryParse(Console.ReadLine(), out numDouble) );
                    Console.WriteLine("Your double +1.0: {0}", numDouble + 1.0);
                    break;
            default:
                    Console.WriteLine("Enter your string");
                    userInput = Console.ReadLine();
                    Console.WriteLine("Your string: " + userInput+ "*");
                break;
        }
    }
}
