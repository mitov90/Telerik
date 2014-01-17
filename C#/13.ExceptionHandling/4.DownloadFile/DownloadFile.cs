using System;
using System.IO;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        string webFile = @"http://www.devbg.org/img/Logo-BASD.jpg";
        string fileName = Path.GetFileName(webFile);

        try
        {
            using ( var wc = new WebClient() )
            {
                wc.DownloadFile(webFile, fileName);
                wc.Dispose();
            }
        }
        catch ( ArgumentNullException e )
        {
            Console.WriteLine(e.Message);
        }
        catch ( WebException e )
        {
            Console.WriteLine(e.Message);
        }
        catch ( NotSupportedException e )
        {
            Console.WriteLine(e.Message);
        }
    }
}
