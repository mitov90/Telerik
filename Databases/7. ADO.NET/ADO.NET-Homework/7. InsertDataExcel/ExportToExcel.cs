namespace InsertDataExcel
{
    using System;
    using System.Data.OleDb;
    using System.IO;

    internal class ExportToExcel
    {
        private static void Main()
        {
            const string Filename = "Students.xlsx";
            var parent = new DirectoryInfo(Environment.CurrentDirectory).Parent;
            if (parent == null || parent.Parent == null)
            {
                return;
            }

            var directoryInfo = parent.Parent.FullName;

            var sourcePath = Path.Combine(directoryInfo, Filename);
            var dbConnectionString = string.Format(Settings.Default.dbConnectionString, sourcePath);
            var dbConnection = new OleDbConnection(dbConnectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                const string Name = "John Doe";
                const int Score = 12;

                var result = InserRow(dbConnection, Name, Score);

                Console.WriteLine("Row affected: " + result);
            }
        }

        private static int InserRow(OleDbConnection dbConnection, string name, int score)
        {
            var cmdInsert = new OleDbCommand(
                "INSERT INTO [Sheet1$] (Name, Score) " + "VALUES(@Name, @Score)", 
                dbConnection);
            cmdInsert.Parameters.AddWithValue("@Name", name);
            cmdInsert.Parameters.AddWithValue("@Score", score);
            return cmdInsert.ExecuteNonQuery();
        }
    }
}