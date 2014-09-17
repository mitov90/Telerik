namespace CategoriesDescription
{
    using System;
    using System.Data.SqlClient;

    internal class CategoriesDescription
    {
        private static void Main()
        {
            var sqlConnection = new SqlConnection(Settings.Default.dbConnectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                var sqlCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories", sqlConnection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = (string)reader["CategoryName"];
                    var description = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", name, description);
                }
            }
        }
    }
}