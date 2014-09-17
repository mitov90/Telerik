namespace BookStore.Client.Console
{
    using System;

    using BookStore.Data;
    using BookStore.XML;

    internal class EntryPointConsole
    {
        private static readonly BookStoreDbContext DbContext = new BookStoreDbContext();

        private static void Main()
        {
            using (DbContext)
            {
                //XmlImporter xmlImporter = new XmlImporter(DbContext);
                //xmlImporter.Import("../../Resources/complex-books.xml");

                ReviewQueriesFromXml queryProcessor = new ReviewQueriesFromXml(DbContext);
                var queriesResult = queryProcessor.ReadXmlQueries("../../Resources/reviews-queries.xml");

                XmlExporter exporter = new XmlExporter();
                exporter.ExportReviews(queriesResult, "../../Resources/reviews-search-results.xml");
            }
        }
    }
}