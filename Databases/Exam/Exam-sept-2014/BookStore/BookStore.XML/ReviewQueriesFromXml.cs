namespace BookStore.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using BookStore.Data;
    using BookStore.Models;

    public class ReviewQueriesFromXml
    {
        private readonly BookStoreDbContext dbContext;

        public ReviewQueriesFromXml(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<IEnumerable<Review>> ReadXmlQueries(string filename)
        {
            IEnumerable<XElement> xmlQueries = XElement.Load(filename).Elements("query");
            IList<IEnumerable<Review>> results = new List<IEnumerable<Review>>();

            foreach (var xmlQuery in xmlQueries)
            {
                string queryType = xmlQuery.Attribute("type").Value;
                IQueryable<Review> queryResult = this.dbContext.Reviews.AsQueryable();

                if (queryType == "by-period")
                {
                    queryResult = QueryByDate(xmlQuery, queryResult);
                }
                else if (queryType == "by-author")
                {
                    queryResult = QueryByAuthor(xmlQuery, queryResult);
                }

                results.Add(queryResult.OrderBy(r => r.CreatedOn).ThenBy(r => r.Content).ToList());
            }

            return results;
        }

        private static IQueryable<Review> QueryByAuthor(XContainer xmlQuery, IQueryable<Review> queryResult)
        {
            XElement xElement = xmlQuery.Element("author-name");

            if (xElement == null)
            {
                return queryResult;
            }

            string authorName = xElement.Value;
            queryResult = queryResult.Where(r => r.Author.Name == authorName);
            return queryResult;
        }

        private static IQueryable<Review> QueryByDate(XContainer xmlQuery, IQueryable<Review> queryResult)
        {
            XElement startDateNode = xmlQuery.Element("start-date");
            XElement endDateNode = xmlQuery.Element("end-date");

            if (startDateNode == null || endDateNode == null)
            {
                return queryResult;
            }

            DateTime startDate = DateTime.Parse(startDateNode.Value);
            DateTime endDate = DateTime.Parse(endDateNode.Value);
            queryResult = queryResult.Where(r => r.CreatedOn >= startDate && r.CreatedOn <= endDate);
            return queryResult;
        }
    }
}