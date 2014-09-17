namespace BooksManager
{
    using System;
    using System.Collections;
    using System.Data;

    using MySql.Data.MySqlClient;

    internal class Manager
    {
        private static void Main()
        {
            Console.WriteLine("Searching for 'ra' in Titles: ");
            var foundBooks = SearchForBook("ra");
            PrintBooks(foundBooks);

            Console.WriteLine(InsertNewBook("Pepelqshka", 1, new DateTime(2012, 1, 2), "no ISBN"));

            Console.WriteLine("Getting all books in db: ");
            var allBooks = GetAllBooks();
            PrintBooks(allBooks);
        }

        private static int InsertNewBook(
        string title,
        int authorId,
        DateTime publicationDate,
        string isbn)
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.dbConnectionString);

            mySqlConnection.Open();
            using (mySqlConnection)
            {
                var insertBookCommand = new MySqlCommand(
                    @"INSERT INTO Books (Title, publishDate, ISBN, authorID)
                    VALUES (@bookTitle, @publicationDate, @isbn, @bookAuthor)",
                    mySqlConnection);

                insertBookCommand.Parameters.AddWithValue("@bookTitle", title);
                insertBookCommand.Parameters.AddWithValue("@bookAuthor", authorId);
                insertBookCommand.Parameters.AddWithValue("@publicationDate", publicationDate);
                insertBookCommand.Parameters.AddWithValue("@isbn", isbn);

                var rowsAffected = insertBookCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        private static void PrintBooks(IEnumerable foundBooks)
        {
            foreach (DataRow row in foundBooks)
            {
                Console.WriteLine(row[0] + " " + row[3] + " " + row[2]);
            }
        }

        private static DataRowCollection SearchForBook(string pattern)
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.dbConnectionString);
            mySqlConnection.Open();
            using (mySqlConnection)
            {
                var result = new DataSet();
                var cmdSearchBook = CreateSearchCmd(pattern, mySqlConnection);
                cmdSearchBook.Fill(result);
                return result.Tables[0].Rows;
            }
        }

        private static MySqlDataAdapter CreateSearchCmd(string pattern, MySqlConnection mySqlConnection)
        {
            var searchCmd = new MySqlDataAdapter(
                @"SELECT b.Title, b.publishDate, b.ISBN, a.AuthorName 
                FROM books b 
                INNER JOIN authors a 
                ON b.authorID = a.authorId 
                WHERE LOCATE(@pattern, b.Title) > 0",
                mySqlConnection);
            searchCmd.SelectCommand.Parameters.AddWithValue("@pattern", pattern);
            return searchCmd;
        }

        private static DataRowCollection GetAllBooks()
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.dbConnectionString);
            mySqlConnection.Open();
            using (mySqlConnection)
            {
                var result = new DataSet();
                var cmdSelectBooks = CreateSelectCmd(mySqlConnection);
                cmdSelectBooks.Fill(result);
                return result.Tables[0].Rows;
            }
        }

        private static MySqlDataAdapter CreateSelectCmd(MySqlConnection mySqlConnection)
        {
            var cmdSelectBooks = new MySqlDataAdapter(
                @"SELECT b.Title, b.publishDate, b.ISBN, a.AuthorName
                FROM books b
                INNER JOIN authors a
                ON b.authorID = a.authorId",
                mySqlConnection);
            return cmdSelectBooks;
        }
    }
}