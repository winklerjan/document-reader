using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using DocumentReader.Model;
using DocumentReader.Service;
using Newtonsoft.Json;
namespace DocumentReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of the source file: ");
            string? sourceFileName = Console.ReadLine();
            string sourceFilePath = Path.Combine("..\\..\\..\\SourceFiles", sourceFileName);

            Console.Write("Enter the name of the target file: ");
            string? targetFileName = Console.ReadLine();
            string targetFilePath = Path.Combine("..\\..\\..\\TargetFiles", targetFileName);

            IDocumentReader documentReader = null;

            if (IsHttpSource(sourceFileName))
            {
                // TODO add logic for http source
            }
            else
            {
                documentReader = new FileSystemDocumentReader();
            }

            string? input = documentReader?.ReadFile(sourceFilePath);

            Enum.FileExtension fileExtension = Helper.GetFileExtension(sourceFileName);

            switch (fileExtension)
            {
                case Enum.FileExtension.XML:
                    break;


            }

            XDocument xdoc = XDocument.Parse(input);

            string title = xdoc.Root.Element("title").Value;
            string text = xdoc.Root.Element("text").Value;

            var doc = new Document(title, text);

            string serializedDoc = JsonConvert.SerializeObject(doc);

            // TODO wrap in a try/catch statement
            using (FileStream targetStream = File.Open(targetFilePath, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(targetStream))
                {
                    sw.Write(serializedDoc);
                }
            }
        }

        private static bool IsHttpSource(string path)
        {
            return path.StartsWith("http") || path.StartsWith("https");
        }
    }
}

