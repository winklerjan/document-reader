using DocumentReader.Service;

namespace DocumentReader
{
    public static class Helper
    {
        public static bool IsHttpSource(string path)
        {
            return path.StartsWith("http") || path.StartsWith("https");
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

        public static IDocumentReader GetStorage(string sourceFileName)
        {
            IDocumentReader documentReader = null;

            if (Helper.IsHttpSource(sourceFileName))
            {
                documentReader = new HttpDocumentReader();
            }
            else
            {
                documentReader = new FileSystemDocumentReader();
            }

            return documentReader;
        }
    }
}
