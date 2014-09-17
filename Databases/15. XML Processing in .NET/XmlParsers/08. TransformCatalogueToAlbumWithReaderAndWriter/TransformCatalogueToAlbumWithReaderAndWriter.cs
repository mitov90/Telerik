//Write a program, which (using XmlReader and
//XmlWriter) reads the file catalog.xml and creates 
//the file album.xml, in which stores in appropriate 
//way the names of all albums and their authors.

//NOTE!!! The new file is in the debug folder.

namespace _08.TransformCatalogueToAlbumWithReaderAndWriter
{
    using System;
    using System.Text;
    using System.Xml;

    public class TransformCatalogueToAlbumWithReaderAndWriter
    {
        public static void Main()
        {
            var reader = XmlReader.Create("Catalogue.xml");
            var writer = new XmlTextWriter("album.xml", Encoding.Unicode);

            Console.WriteLine("Starting...");

            using (reader)
            {
                using (writer)
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        if (reader.Name.Equals("album") && reader.IsStartElement())
                        {
                            writer.WriteStartElement("album");

                            reader.ReadToDescendant("name");

                            string albumName = reader.ReadElementContentAsString();

                            reader.ReadToNextSibling("artist");

                            string authorName = reader.ReadElementContentAsString();

                            writer.WriteElementString("name", albumName);
                            writer.WriteElementString("author", authorName);

                            writer.WriteEndElement();
                        }
                    }
                }
            }

            Console.WriteLine("Done!");
        }
    }
}
