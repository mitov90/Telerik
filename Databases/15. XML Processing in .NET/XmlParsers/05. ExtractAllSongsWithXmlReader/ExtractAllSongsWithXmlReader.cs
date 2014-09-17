//Write a program, which using XmlReader extracts 
//all song titles from catalog.xml.

namespace _05.ExtractAllSongsWithXmlReader
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractAllSongsWithXmlReader
    {
        public static void Main()
        {
            List<string> songs = new List<string>();

            using (var reader = XmlReader.Create("Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name.Equals("song") && reader.IsStartElement())
                    {
                        reader.ReadToDescendant("title");

                        songs.Add(reader.ReadElementContentAsString());
                    }
                }
            }

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
