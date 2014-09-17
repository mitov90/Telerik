//Using the DOM parser write a program to delete 
//from catalog.xml all albums having price > 20.

//NOTE!!! The xml document is in the debug folder.
namespace _04.DeleteSomeNodesWithDomParser
{
    using System.Xml;

    public class DeleteSomeNodesWithDomParser
    {
        public static void Main()
        {
            XmlDocument document = new XmlDocument();

            document.Load("Catalogue.xml");

            //The document has 4 albums initially, 2 are with price > 20
            var albums = document.SelectNodes("//album");

            foreach (XmlNode album in albums)
            {
                var priceNode = album.SelectSingleNode("price");
                var price = decimal.Parse(priceNode.InnerText);

                if (price > 20)
                {
                    album.ParentNode.RemoveChild(album);
                }
            }

            //Aftert he save, the document has two albums.
            document.Save("Catalogue.xml");
        }
    }
}
