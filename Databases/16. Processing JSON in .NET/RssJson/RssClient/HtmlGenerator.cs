using System.Collections.Generic;
using System.Text;

using RssClient;

public class HtmlGenerator
{
    private const string ItemTemplate = "<li><a href=\"{0}\">[{1}] {2} ({3})</a></li>";

    public string GenerateHtml(IEnumerable<Item> listItems)
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<ul>");

        foreach (var item in listItems)
        {
            html.AppendFormat(
                ItemTemplate,
                item.Link,
                item.Category,
                item.Title, 
                item.PubDate.ToShortDateString());
        }

        html.AppendLine("<ul>");
        return html.ToString();
    }
}