namespace GetCertainAlbumsWithLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class GetCertainAlbumsWithLinq
    {
        public static void Main()
        {
            XDocument document = XDocument.Load("Catalogue.xml");

            IEnumerable<string> prices = document.Descendants("album").Where(
                album =>
                    {
                        XElement firstOrDefault = album.Descendants("year").FirstOrDefault();
                        return firstOrDefault != null && int.Parse(firstOrDefault.Value) <= 2009;
                    }).Select(
                        album =>
                            {
                                XElement orDefault = album.Descendants("price").FirstOrDefault();
                                return orDefault != null ? orDefault.Value : null;
                            });

            foreach (string price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}