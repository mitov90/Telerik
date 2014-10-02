using System.Diagnostics;

internal class WindowsDirectoryTraversalRunner
{
    private static void Main()
    {
        var startInfo = new ProcessStartInfo(WindowsDirectoryTraversal.Location) { Verb = "runas" };
        Process.Start(startInfo);
    }
}
