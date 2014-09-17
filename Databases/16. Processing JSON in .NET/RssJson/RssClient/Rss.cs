namespace RssClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class Rss
    {
        private const string RssSource = @"http://forums.academy.telerik.com/feed/qa.rss";
        private const string XmlRss = "../../rss.xml";
        private const string HtmlRss = "../../index.html";


        private static void Main()
        {
            // Make sure cyrillic is supported in console
            Console.OutputEncoding = Encoding.Unicode;

            // 2. Download content of the feed
            using (WebClient wb = new WebClient())
            {
                wb.DownloadFile(RssSource, XmlRss);
            }

            // 3. Parse the xml to json
            XDocument doc = XDocument.Load(XmlRss);

            string json = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            // 4. Getting all titles with LINQ
            JObject jsonObj = JObject.Parse(json);
            IEnumerable<JToken> titles = jsonObj["rss"]["channel"]["item"].Select(i => i["title"]);

            // Printing all titles
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            // 5. Parse json string to POCO
            string jsonItems = jsonObj["rss"]["channel"]["item"].ToString();
            Item[] items = JsonConvert.DeserializeObject<Item[]>(jsonItems);
            Array.ForEach(items, Console.WriteLine);

            // 6. Using the parsed objects create a HTML page that 
            // lists all questions from the RSS their categories and 
            // a link to the question's page
            CreateHtmlPage(items);
        }

        private static void CreateHtmlPage(IEnumerable<Item> items)
        {
            var htmlGenerator = new HtmlGenerator();
            string html = htmlGenerator.GenerateHtml(items);
            FileUtils.CreateFile(HtmlRss, html);

            Console.WriteLine("Html page saved to <{0}>", HtmlRss);
        }
    }
}