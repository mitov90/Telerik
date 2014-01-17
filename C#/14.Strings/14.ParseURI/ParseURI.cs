using System;

class ParseURI
{
    static void Main()
    {
        string input = "http://www.devbg.org/forum/index.php";

        var uri = new Uri(input);

        Console.WriteLine(uri.GetComponents(UriComponents.Scheme, UriFormat.Unescaped));
        Console.WriteLine(uri.GetComponents(UriComponents.Host, UriFormat.Unescaped));
        Console.WriteLine(uri.GetComponents(UriComponents.PathAndQuery,UriFormat.Unescaped));

    }
}
