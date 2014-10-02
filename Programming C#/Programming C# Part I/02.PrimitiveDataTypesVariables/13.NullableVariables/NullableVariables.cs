using System;

class NullableVariables
{
    static void Main()
    {
        int? intVar = null;
        double? doubleVar = null;
        Console.WriteLine("int: {0}, double: {1}", intVar,doubleVar);

        intVar += 1;
        doubleVar += 3.14;
        Console.WriteLine("int: {0}, double: {1}", intVar, doubleVar);

        intVar = intVar.GetValueOrDefault() + 1;
        doubleVar = doubleVar.GetValueOrDefault() + 3.14;
        Console.WriteLine("int: {0}, double: {1}", intVar, doubleVar);

    }
}

