namespace TurnXmlToHtml
{
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    // Write a C# program to apply the XSLT stylesheet 
    // transformation on the file catalog.xml using the 
    // class XslTransform
    // class XslTransform.
    public class TurnXmlToHtml
    {
        public static void Main()
        {
            XPathDocument myXPathDoc = new XPathDocument("Catalogue.xml");
            XslTransform myXslTrans = new XslTransform();

            myXslTrans.Load("stylesheet.xslt");

            XmlTextWriter myWriter = new XmlTextWriter("result.html", Encoding.Unicode);

            myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
    }
}