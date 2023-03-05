using DocumentReader.Model;
using Newtonsoft.Json;

namespace DocumentReader.Service
{
    internal class JsonDocumentConverter : IDocumentConverter
    {
        public Document Deserialize(string input)
        {
            return JsonConvert.DeserializeObject<Document>(input);
        }

        public string Serialize(Document document)
        {
            return JsonConvert.SerializeObject(document);
        }
    }
}
