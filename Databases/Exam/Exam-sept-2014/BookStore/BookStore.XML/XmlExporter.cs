namespace BookStore.XML
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using BookStore.Models;

    public class XmlExporter
    {
        public void ExportReviews(IList<IEnumerable<Review>> data, string filename)
        {
            XElement xmlFile = new XElement("search-results");

            foreach (var resultSets in data)
            {
                XElement xmlSet = new XElement("result-set");

                foreach (var review in resultSets)
                {
                    XElement xmlReview = new XElement(
                        "review", 
                        new XElement("date", review.CreatedOn.ToString("d-MMM-yyyy")), 
                        new XElement("content", review.Content));

                    Book book = review.Book;
                    XElement xmlBook = new XElement("book", new XElement("title", book.Title));

                    this.AddAuthors(book, xmlBook);
                    this.AddIsbn(book, xmlBook);
                    this.AddWebsite(book, xmlBook);
                    xmlReview.Add(xmlBook);
                    xmlSet.Add(xmlReview);
                }

                xmlFile.Add(xmlSet);
            }

            xmlFile.Save(filename);
        }

        private void AddIsbn(Book book, XElement xmlBook)
        {
            if (book.Isbn != null)
            {
                return;
            }

            XElement xmlIsbn = new XElement("isbn", book.Isbn);
            xmlBook.Add(xmlIsbn);
        }

        private void AddWebsite(Book book, XContainer xmlBook)
        {
            if (book.Website != null)
            {
                return;
            }

            XElement xmlWebsite = new XElement("url", book.Website);
            xmlBook.Add(xmlWebsite);
        }

        private void AddAuthors(Book book, XContainer xmlBook)
        {
            if (!book.Authors.Any())
            {
                return;
            }

            IEnumerable<string> authorsName = book.Authors.Select(a => a.Name);
            string authorsNamesAsString = string.Join(", ", authorsName);
            XElement xmlAuthors = new XElement("authors", authorsNamesAsString);
            xmlBook.Add(xmlAuthors);
        }
    }
}