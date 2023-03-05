using DocumentReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Service
{
    public interface IDocumentConverter
    {
        string Serialize(Document document);
        Document Deserialize(string input);
    }
}
