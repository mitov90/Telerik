namespace GetDataFromExcel
{
    using System;
    using System.Data.OleDb;
    using System.IO;

    public class ExcelFileReader
    {
        public static void Main()
        {
            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory).
                Parent.
                Parent.
                FullName;

            var sourcePath = Path.Combine(directoryInfo, "Students.xlsx");
            var dbConnectionString = string.Format(Settings.Default.dbConnectionString, sourcePath);
            var dbConnection = new OleDbConnection(dbConnectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                var cmdReader = new OleDbCommand("SELECT * FROM [Sheet1$]", dbConnection);
                var reader = cmdReader.ExecuteReader();
                Console.WriteLine("Name".PadRight(20) + "Score");
                while (reader != null && reader.Read())
                {
                    var name = reader[0];
                    var score = reader[1];
                    Console.WriteLine(name.ToString().PadRight(20) + score);
                }
            }
        }
    }
}
