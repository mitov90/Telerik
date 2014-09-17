using System;

class EscapeQuotes
{
    static void Main()
    {
        string quotedText = "The \"use\" of quotations causes difficulties.";
        string quotedTxt = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine(quotedText);
        Console.WriteLine(quotedTxt);
    }
}