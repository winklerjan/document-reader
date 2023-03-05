using DocumentReader.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader
{
    internal static class Mapper
    {
        public static Enum.FileFormat MapFileFormat(string format)
        {
            switch(format.ToLower()) {
                case ".xml": case "xml": return Enum.FileFormat.XML;
                case ".json": case "json": return Enum.FileFormat.JSON;
                case ".bson": case "bson": return Enum.FileFormat.BSON;
                case ".yaml": case "yaml": return Enum.FileFormat.YAML;
                default: throw new NotSupportedException($"Unsupported file format ({format}).");
            
            
            }
        }

        public static IDocumentConverter GetDocumentConverter(string format)
        {
            switch (format.ToLower())
            {
                case "xml": case ".xml": return new XmlDocumentConverter();
                case "json": case ".json": return new JsonDocumentConverter();
                default: throw new NotSupportedException($"Format {format} not supported.");
            }
        }
    }
}
