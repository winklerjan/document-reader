using DocumentReader.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
