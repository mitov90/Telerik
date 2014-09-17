namespace BookStore.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using BookStore.Data;
    using BookStore.Models;

    public class XmlImporter
    {
        private readonly BookStoreDbContext dbContext;

        public XmlImporter(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Import(string filename)
        {
            IEnumerable<XElement> bookNodes = XElement.Load(filename).Elements("book");

            foreach (var bookNode in bookNodes)
            {
                Book book = new Book();

                XElement xElement = bookNode.Element("title");
                if (xElement != null)
                {
                    string title = xElement.Value;
                    book.Title = title;
                }

                IEnumerable<Author> authors = this.GetAuthors(bookNode);
                foreach (var author in authors)
                {
                    book.Authors.Add(author);
                }

                IEnumerable<Review> reviews = this.GetReviews(bookNode);
                foreach (var review in reviews)
                {
                    book.Reviews.Add(review);
                }

                XElement website = bookNode.Element("web-site");
                if (website != null)
                {
                    book.Website = website.Value;
                }

                XElement isbn = bookNode.Element("isbn");
                if (isbn != null)
                {
                    book.Isbn = isbn.Value;
                }

                XElement price = bookNode.Element("price");
                if (price != null)
                {
                    book.Price = decimal.Parse(price.Value);
                }

                this.dbContext.Books.Add(book);
                this.dbContext.SaveChanges();
            }
        }

        private IEnumerable<Review> GetReviews(XContainer bookNode)
        {
            IEnumerable<XElement> reviewNodes = bookNode.Elements("reviews");
            List<Review> reviews = new List<Review>();

            foreach (var reviewNode in reviewNodes.Elements("review"))
            {
                Review review = new Review { Content = reviewNode.Value, };
                XAttribute authorName = reviewNode.Attribute("author");
                if (authorName != null)
                {
                    review.Author = this.GetOrCreateAuthor(authorName.Value);
                }

                XAttribute createdOn = reviewNode.Attribute("date");
                review.CreatedOn = createdOn != null ? DateTime.Parse(createdOn.Value) : DateTime.Now;

                reviews.Add(review);
            }

            return reviews;
        }

        private IEnumerable<Author> GetAuthors(XContainer bookNode)
        {
            IEnumerable<XElement> authorNodes = bookNode.Elements("authors");
            List<Author> authors = new List<Author>();

            authors.AddRange(
                authorNodes.Elements("author").Select(authorNode => this.GetOrCreateAuthor(authorNode.Value)));

            return authors;
        }

        private Author GetOrCreateAuthor(string authorName)
        {
            return this.dbContext.Authors.FirstOrDefault(a => a.Name == authorName) ?? new Author { Name = authorName };
        }
    }
}