#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

#endregion

internal class ExtractContentFromXml
{
    private static void Main()
    {
        string sourcefilePath;

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourcefilePath = Console.ReadLine();
            if (sourcefilePath != null && !sourcefilePath.EndsWith(".xml"))
                sourcefilePath = null;

        } while ( !File.Exists(sourcefilePath) );

        Match match = null;

        if (sourcefilePath != null)
            using (var reader = new StreamReader(sourcefilePath))
            {
                var input = reader.ReadToEnd();
                var patternRegex = new Regex(">(?<word>[^/<>]+?)</");
                match = patternRegex.Match(input);
            }

        List<string> matchList= new List<string>();

        while (match != null && match.Success)
        {
            matchList.Add(match.Groups["word"].Value);
            match = match.NextMatch();
        }

        foreach (var value in matchList)
        {
            Console.WriteLine(value);
        }

        
    }
}