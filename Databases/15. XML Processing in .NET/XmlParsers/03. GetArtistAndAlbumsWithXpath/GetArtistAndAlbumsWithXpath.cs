//Implement the previous using XPath.

namespace _02.GetAllDifferentArtistsAndNumberOfAlbums
{
    using System;
    using System.Collections;
    using System.Xml;

    public class GetArtistAndAlbumsWithXpath
    {
        public static void Main()
        {
            Hashtable artistsWithAlbums = new Hashtable();
            XmlDocument document = new XmlDocument();

            document.Load("Catalogue.xml");

            var albums = document.SelectNodes("//album");

            foreach (XmlNode album in albums)
            {
                var artist = album.SelectSingleNode("artist").InnerText;

                if (artistsWithAlbums.ContainsKey(artist))
                {
                    artistsWithAlbums[artist] = (int)artistsWithAlbums[artist] + 1;
                }
                else
                {
                    artistsWithAlbums[artist] = 1;
                }
            }

            foreach (var artistName in artistsWithAlbums.Keys)
            {
                Console.WriteLine("{0} => {1}", artistName, artistsWithAlbums[artistName]);
            }
        }
    }
}