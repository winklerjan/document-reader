using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
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
            //Console.Write("Enter the location of the source file: ");
            //string sourceFileLocation = Console.ReadLine();
            //Console.Write("Enter the name of the source file: ");
            //string sourceFileName = Console.ReadLine();
            string sourceFileName = "xmlhahaha.xml";
            string sourceFilePath = Path.Combine("C:\\Users\\jan\\Desktop\\xmlhahaha.xml");
            //string sourceFilePath = Path.Combine(sourceFileLocation, sourceFileName);

            //Console.Write("Enter the location of the target file: ");
            //string? targetFileLocation = Console.ReadLine();
            //Console.Write("Enter the name of the target file: ");
            //string targetFileName = Console.ReadLine();
            //string targetFileName = "xmlhahaha.xml";
            string targetFilePath = Path.Combine("C:\\Users\\jan\\Desktop\\json.json");
            //string targetFilePath = Path.Combine(targetFileLocation, targetFileName);

            Console.Write("Which format would you like to convert to? ");
            string targetFileFormat = Console.ReadLine();

            IDocumentReader documentReader = null;

            if (Helper.IsHttpSource(sourceFileName))
            {
                // TODO add logic for http source
            }
            else
            {
                documentReader = new FileSystemDocumentReader();
            }

            string input = documentReader.ReadFile(sourceFilePath);
            string sourceFileFormat = new FileInfo(sourceFileName).Extension;
            
            IDocumentConverter fileConverter = Mapper.GetDocumentConverter(sourceFileFormat);
            Document deserializedDoc = fileConverter.Deserialize(input);

            fileConverter = Mapper.GetDocumentConverter(targetFileFormat);
            string serializedDoc = fileConverter.Serialize(deserializedDoc);

            try
            {
                using (FileStream targetStream = File.Open(targetFilePath, FileMode.Create, FileAccess.Write))
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

