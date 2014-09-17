//Write program that extracts all different artists 
//which are found in the catalog.xml. For each 
//author you should print the number of albums in the 
//catalogue. Use the DOM parser and a hash-table.

namespace _02.GetAllDifferentArtistsAndNumberOfAlbums
{
    using System;
    using System.Collections;
    using System.Xml;

    public class GetAllDifferentArtistsAndNumberOfAlbums
    {
        public static void Main()
        {
            Hashtable artistsWithAlbums = new Hashtable();
            XmlDocument document = new XmlDocument();

            document.Load("Catalogue.xml");

            XmlNode root = document.DocumentElement;

            foreach (XmlNode album in root.ChildNodes)
            {
                foreach (XmlNode info in album.ChildNodes)
                {
                    if (info.Name.Equals("artist"))
                    {
                        if (artistsWithAlbums.ContainsKey(info.InnerText))
                        {
                            artistsWithAlbums[info.InnerText] = (int)artistsWithAlbums[info.InnerText] + 1;
                        }
                        else
                        {
                            artistsWithAlbums[info.InnerText] = 1;
                        }
                    }
                }


            }

            foreach (var artistName in artistsWithAlbums.Keys)
            {
                Console.WriteLine("{0} => {1}", artistName, artistsWithAlbums[artistName]);
            }
        }
    }
}
