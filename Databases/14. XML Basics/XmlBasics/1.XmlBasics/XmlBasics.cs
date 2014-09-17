/* 1.What does the XML language represents? What does it used for? 
 * 
 * Extensible Markup Language (XML) is a markup language that defines
 * a set of rules for encoding documents in a format that is both 
 * human-readable and machine-readable.
 * The design goals of XML emphasize simplicity, generality, and
 * usability over the Internet. It is a textual data format with
 * strong support via Unicode for different human languages. Although
 * the design of XML focuses on documents, it is widely used for the 
 * representation of arbitrary data structures, for example in web 
 * services.
 * 
 * 3.What does the namespaces represents in the XML documents? 
 * What are they used for? 
 * 
 * XML namespaces are used for providing uniquely named elements and 
 * attributes in an XML document. They are defined in a W3C 
 * recommendation. An XML instance may contain element or attribute
 * names from more than one XML vocabulary. If each vocabulary is 
 * given a namespace, the ambiguity between identically named elements
 * or attributes can be resolved.
 * A simple example would be to consider an XML instance that
 * contained references to a customer and an ordered product. Both the 
 * customer element and the product element could have a child element
 * named id. References to the id element would therefore be ambiguous
 * placing them in different namespaces would remove the ambiguity.
*/
namespace XmlBasics
{
    using System;

    internal class XmlBasics
    {
        private static void Main()
        {
            Console.WriteLine("Read XmlBasics");
        }
    }
}