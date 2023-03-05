using DocumentReader.Model;
using DocumentReader.Service;
namespace DocumentReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the location of the source file: ");
            string sourceFileLocation = Console.ReadLine();
            Console.Write("Enter the name of the source file: ");
            string sourceFileName = Console.ReadLine();
            string sourceFilePath = Path.Combine(sourceFileLocation, sourceFileName);

            Console.Write("Enter the location of the target file: ");
            string targetFileLocation = Console.ReadLine();
            Console.Write("Enter the name of the target file: ");
            string targetFileName = Console.ReadLine();
            string targetFilePath = Path.Combine(targetFileLocation, targetFileName);

            Console.Write("Which format would you like to convert to? ");
            string targetFileFormat = Console.ReadLine();

            IDocumentReader documentReader = Helper.GetStorage(sourceFileName);

            string input = documentReader.ReadFile(sourceFilePath);
            string sourceFileFormat = new FileInfo(sourceFileName).Extension;
            
            IDocumentConverter fileConverter = Helper.GetDocumentConverter(sourceFileFormat);
            Document deserializedDoc = fileConverter.Deserialize(input);

            fileConverter = Helper.GetDocumentConverter(targetFileFormat);
            string serializedDoc = fileConverter.Serialize(deserializedDoc);

            try
            {
                using (FileStream targetStream = File.Open($"{targetFilePath}.{targetFileFormat.Trim('.')}", FileMode.Create, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(targetStream))
                    {
                        sw.Write(serializedDoc);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            
        }
    }
}

