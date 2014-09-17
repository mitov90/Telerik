namespace SearchForProduct
{
    using System;
    using System.Data.SqlClient;

    internal class ProductSearcher
    {
        private static void Main()
        {
            var sqlConnection = new SqlConnection(Settings.Default.dbConnectionString);
            var userSearch = GetSearchString();
            sqlConnection.Open();
            using (sqlConnection)
            {
                var cmdSearch = CreateSqlCommand(sqlConnection, userSearch);

                var reader = cmdSearch.ExecuteReader();
                while (reader.Read())
                {
                    var productName = reader["ProductName"];
                    Console.WriteLine(productName);
                }
            }
        }

        private static SqlCommand CreateSqlCommand(SqlConnection sqlConnection, string userSearch)
        {
            var cmdSearch = new SqlCommand(
                    @"SELECT ProductName
                    FROM Products
                    WHERE CHARINDEX(@pattern, ProductName) > 0",
                    sqlConnection);

            cmdSearch.Parameters.AddWithValue("@pattern", userSearch);
            return cmdSearch;
        }

        private static string GetSearchString()
        {
            Console.WriteLine("Enter product search string: ");
            var userSearch = Console.ReadLine();
            return userSearch;
        }
    }
}