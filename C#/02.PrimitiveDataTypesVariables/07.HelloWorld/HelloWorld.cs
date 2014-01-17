using System;

class HelloWorld
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object obj = hello + " " + world;
        string helloWorld = (string)obj;
        Console.WriteLine(helloWorld);
    }
}
