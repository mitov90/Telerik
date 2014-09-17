using System;
using System.IO;
using System.Reflection;
using System.Text;

public class WindowsDirectoryTraversal
{

    private const string SearchPattern = "*.exe";
    private static readonly string WindowsPath = Environment.GetEnvironmentVariable("windir");

    private static readonly StringBuilder Log = new StringBuilder();

    public static string Location
    {
        get
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }

    private static void WalkDirectoryTree(string path)
    {
        string[] filePaths = null;

        // First, process all the files directly under this folder 
        try
        {
            filePaths = Directory.GetFiles(path, SearchPattern);
        }

            // than the application provides. 
            // This is thrown if even one of the files requires permissions greater 
        catch (UnauthorizedAccessException uaex)
        {
            // This code just writes out the message and continues to recurse. 
            // You may decide to do something different here. For example, you 
            // can try to elevate your privileges and access the file again.
            Log.AppendLine(uaex.Message);
        }
        catch (DirectoryNotFoundException dnfex)
        {
            Log.AppendLine(dnfex.Message);
        }

        if (filePaths != null)
        {
            foreach (var filePath in filePaths)
            {
                // In this example, we only access the existing file. If we 
                // want to open, delete or modify the file, then 
                // a try-catch block is required here to handle the case 
                // where the file has been deleted since the call to WalkDirectoryTree().
                Console.WriteLine(filePath);
            }

            // Now find all the subdirectories under this directory.
            string[] subdirectories = Directory.GetDirectories(path);

            foreach (var subdirectory in subdirectories)
            {
                // Recursive call for each subdirectory.
                WalkDirectoryTree(subdirectory);
            }
        }
    }

    private static void Main()
    {
        Log.Clear();

        WalkDirectoryTree(WindowsPath);

        Console.WriteLine(Log);

        // A manifest file has been created where the highest available execution level
        // has been requested (<requestedExecutionLevel  level="highestAvailable" uiAccess="false" />).
        // Because of the privileges elevation (to avoid the UnauthorizedAccessException where possible), 
        // the application starts in another console window which should be prevented from
        // closing when the program finishes.
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey();
    }
}
