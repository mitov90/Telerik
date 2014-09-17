namespace BookStore.Data
{
    using System.Data.Entity;

    using BookStore.Data.Migrations;
    using BookStore.Models;

    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : base("name=BookStoreDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Review> Reviews { get; set; }
    }
}