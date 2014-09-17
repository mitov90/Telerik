//Rewrite the same using XDocument and LINQ query.

namespace _06.ExtractAllSongsWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractAllSongsWithLinq
    {
        public static void Main()
        {
            var document = XDocument.Load("Catalogue.xml");

            var songs = document.Descendants("song")
                .Select(song => song.Descendants("title").First().Value)
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
