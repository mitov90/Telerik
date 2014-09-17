namespace ValidateWithXsd
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    // Using Visual Studio generate an XSD schema for the 
    // file catalog.xml. Write a C# program that takes an 
    // XML file and an XSD file (schema) and validates the 
    // XML file against the schema. Test it with valid XML 
    // catalogs and invalid XML catalogs.
    public class ValidateWithXsd
    {
        public static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(string.Empty, "Catalogue.xsd");

            XDocument validateDoc = XDocument.Load("Catalogue.xml");
            bool errors = false;

            validateDoc.Validate(
                schemas, 
                (o, e) =>
                    {
                        Console.WriteLine("{0}", e.Message);
                        errors = true;
                    });

            Console.WriteLine("First document is {0} valid", errors ? "not" : string.Empty);

            schemas = new XmlSchemaSet();
            schemas.Add(string.Empty, "Catalogue.xsd");

            XDocument invalidDocument = XDocument.Load("Catalogue - Copy.xml");
            errors = false;

            invalidDocument.Validate(
                schemas, 
                (o, e) =>
                    {
                        Console.WriteLine("{0}", e.Message);
                        errors = true;
                    });

            Console.WriteLine("Second document is {0} valid", errors ? "not" : string.Empty);
        }
    }
}