namespace RssClient
{
    using System;

    public class Item
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime PubDate { get; set; }

        public override string ToString()
        {
            return this.PubDate.ToString("g") + ":" + this.Title + " -> " + this.Category;
        }
    }
}