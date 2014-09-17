namespace CategoriesNumberFromNorthwind
{
    using System;
    using System.Data.SqlClient;

    public class GetCategoriesCount
    {
        private static void Main()
        {
            var sqlConnection = new SqlConnection(Settings.Default.dbConnectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                var sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Categories", sqlConnection);
                var categoriesCount = (int)sqlCommand.ExecuteScalar();
                Console.WriteLine("Number of rows in Categories table: " + categoriesCount);
            }
        }
    }
}