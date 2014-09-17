//Write a program to traverse given directory and 
//write to a XML file its contents together with all 
//subdirectories and files. Use tags <file> and <dir>
//with appropriate attributes. For the generation of 
//the XML document use the class XmlWriter.

//NOTE!!! The xml file is in the Debug folder.

namespace _09.DirectoryToXmlWithWriter
{
    using System.IO;
    using System.Text;
    using System.Xml;

    public class DirectoryToXmlWithWriter
    {
        public static void Main()
        {
            var initialDirectoryName = "09. DirectoryToXmlWithWriter";
            var initialDirectory = @"..\..\..\" + initialDirectoryName;

            var writer = new XmlTextWriter("directoryContent.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                writer.WriteStartDocument();

                AddDirectory(initialDirectory, writer);
            }
        }

        private static void AddDirectory(string directory, XmlTextWriter writer)
        {
            var subDirectories = Directory.EnumerateDirectories(directory);

            writer.WriteStartElement("dir");
            var directoryName = directory.Split(new char[] { '\\' });
            writer.WriteAttributeString("name", directoryName[directoryName.Length - 1]);

            foreach (var subDirectory in subDirectories)
            {
                AddDirectory(subDirectory, writer);
            }

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Split(new char[] { '\\' });
                writer.WriteElementString("file", fileName[fileName.Length - 1]);
            }

            writer.WriteEndElement();
        }
    }
}
