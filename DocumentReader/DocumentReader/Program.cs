﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using DocumentReader.Model;
using Newtonsoft.Json;
namespace DocumentReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of the source file: ");
            string sourceFileName = Console.ReadLine();
            string sourceFilePath = Path.Combine("..\\..\\..\\SourceFiles", sourceFileName);

            Console.Write("Enter the name of the target file: ");
            string targetFileName = Console.ReadLine();
            string targetFilePath = Path.Combine("..\\..\\..\\TargetFiles", targetFileName);

            string input;

            try
            {
                FileStream sourceStream = File.Open(sourceFilePath, FileMode.Open);
                StreamReader reader = new StreamReader(sourceStream);
                input = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                // TODO throw more detailed exceptions
                throw new Exception(ex.Message);
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
    }
}

