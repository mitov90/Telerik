namespace ProductsInCategories
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    internal class CategoriesProducts
    {
        private static void Main()
        {
            var sqlConnection = ConnectToDatabase();
            using (sqlConnection)
            {
                var reader = GetReader(sqlConnection);
                var curCategoryName = string.Empty;
                while (reader.Read())
                {
                    curCategoryName = PrintProductsWithCategory(reader, curCategoryName);
                }
            }
        }

        private static string PrintProductsWithCategory(IDataRecord reader, string curCategoryName)
        {
            var categoryName = (string)reader["CategoryName"];
            if (string.IsNullOrEmpty(curCategoryName) || curCategoryName != categoryName)
            {
                Console.WriteLine();
                curCategoryName = categoryName;
                Console.Write(categoryName + " - ");
            }

            var product = (string)reader["ProductName"];
            Console.Write(product + " ");
            return curCategoryName;
        }

        private static SqlDataReader GetReader(SqlConnection sqlConnection)
        {
            var sqlCommand =
                new SqlCommand(
                    "SELECT c.CategoryName, p.ProductName " + "FROM dbo.Categories c " + "INNER JOIN dbo.Products p "
                    + "ON c.CategoryID = p.CategoryID ",
                    sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            return reader;
        }

        private static SqlConnection ConnectToDatabase()
        {
            var sqlConnection = new SqlConnection(Settings.Default.dbConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}