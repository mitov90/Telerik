using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

internal class BooksManagerEmbedded
{
    private static SQLiteConnection GetConnection(string filePath)
    {
        var connection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", filePath));

        return connection;
    }

    private static DataSet FindBooks(string filePath, string searchString)
    {
        searchString = searchString.
            Replace("%", "!%").
            Replace("'", "!'").
            Replace("\"", "!\"").
            Replace("_", "!_").
            ToLower();

        var connection = GetConnection(filePath);

        connection.Open();
        using (connection)
        {
            var dataSet = new DataSet();

            var adapter = new SQLiteDataAdapter(
                string.Format(
                @"SELECT BookTitle, BookAuthor 
                  FROM Books
                  WHERE LOWER(BookTitle) LIKE '%{0}%' ESCAPE '!'",
                    searchString),
                    connection);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static DataSet GetAllBooks(string filePath)
    {
        var connection = GetConnection(filePath);

        connection.Open();
        using (connection)
        {
            var dataSet = new DataSet();

            var adapter = new SQLiteDataAdapter("SELECT BookTitle, BookAuthor FROM Books", connection);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static int InsertNewBook(
        string filePath, 
        string title, 
        string author, 
        DateTime publicationDate, 
        string isbn)
    {
        var connection = GetConnection(filePath);

        connection.Open();
        using (connection)
        {
            var insertBookCommand = new SQLiteCommand(@"INSERT INTO Books (BookTitle, BookAuthor, PublicationDate, ISBN)
                  VALUES (@bookTitle, @bookAuthor, @publicationDate, @isbn)", connection);

            insertBookCommand.Parameters.AddWithValue("@bookTitle", title);
            insertBookCommand.Parameters.AddWithValue("@bookAuthor", author);
            insertBookCommand.Parameters.AddWithValue("@publicationDate", publicationDate);
            insertBookCommand.Parameters.AddWithValue("@isbn", isbn);

            var rowsAffected = insertBookCommand.ExecuteNonQuery();
            return rowsAffected;
        }
    }

    private static void Main()
    {
        var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        var resourcesDirectoryName = Path.Combine(currentDirectory.Parent.Parent.FullName, "Resources");
        var dbFilePath = Path.Combine(resourcesDirectoryName, "bookshop.sqlite");

        Console.Write("Search book titles for: ");
        var searchString = Console.ReadLine();

        var booksDataSet = FindBooks(dbFilePath, searchString);

        foreach (DataRow row in booksDataSet.Tables[0].Rows)
        {
            Console.WriteLine("{0, -20}{1, -20}", row["BookTitle"], row["BookAuthor"]);
        }

        // int rowsAffected = InsertNewBook(
        // dbFilePath,
        // "Pro ASP.NET MVC 4",
        // "Adam Freeman",
        // new DateTime(2013, 1, 16),
        // "978-1430242369");

        // Console.WriteLine("({0} row(s) affected)", rowsAffected);
    }
}