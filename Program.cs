using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Path: ");
        var path = Console.ReadLine();
        var newPath = $"{Path.GetDirectoryName(path)}Encrypted.txt";

        if (Path.GetExtension(path) == ".txt")
        {
            Console.WriteLine("Key: ");
            var key = char.Parse(Console.ReadLine());

            ThreadPool.QueueUserWorkItem(tp =>
            {
                EncryptedFile(path, key, newPath);
            });
        }
        else
        {
            Console.WriteLine("Invalid path");
        }
        Console.ReadKey();
    }

    static void EncryptedFile(string path, char key, string newPath)
    {
        try
        {
            var text = File.ReadAllText(path);
            var sb = new StringBuilder();
            foreach (var item in text)
            {
                sb.Append(item ^ key);
            }

            File.WriteAllText(newPath, sb.ToString());

            Console.WriteLine("File Encrypted Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}