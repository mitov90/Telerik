using System.IO;
using System.Text;

public static class FileUtils
{
    public static string ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File does not exist: " + path);
        }

        string content = string.Empty;

        using (StreamReader reader = new StreamReader(path))
        {
            content = reader.ReadToEnd();
        }

        return content;
    }

    public static void CreateFile(string path, string text)
    {
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}