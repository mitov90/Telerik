using System;

class HelloUser
{
    static void Main()
    {
        RegardsUser();
    }

    static void RegardsUser()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Hello, " + userName + "!");
    }
}
