namespace RetrievePicture
{
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    internal class GetCategoriesPictures
    {
        private const int OleMetafile = 78;

        private static void Main()
        {
            var sqlConnection = new SqlConnection(Settings.Default.dbConnectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                var cmdGetPictures =
                    new SqlCommand(
                        "SELECT c.CategoryID, c.Picture " +
                        "FROM Categories c " +
                        "WHERE Picture IS NOT NULL", 
                        sqlConnection);
                var reader = cmdGetPictures.ExecuteReader();
                while (reader.Read())
                {
                    var filename = (int)reader["CategoryID"] + ".jpg";
                    var image = reader["Picture"] as byte[];
                    SaveImageToFile(filename, image);
                }
            }
        }

        private static void SaveImageToFile(string filename, byte[] imageByteArray)
        {
            using (var ms = new MemoryStream(imageByteArray, OleMetafile, imageByteArray.Length - OleMetafile))
            {
                var image = Image.FromStream(ms);
                using (image)
                {
                    image.Save(filename, ImageFormat.Jpeg);
                }
            }
        }
    }
}