using DocumentReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DocumentReader.Service
{
    public class XmlDocumentConverter : IDocumentConverter
    {
        public Document Deserialize(string input)
        {
            XDocument xdoc = XDocument.Parse(input);

            string title = xdoc.Root.Element("title").Value;
            string text = xdoc.Root.Element("text").Value;

            var doc = new Document(title, text);

            return doc;
        }

        public string Serialize(Document document)
        {
            var xdoc = new XDocument(
                new XElement("document",
                    new XElement("title", document.Title),
                    new XElement("text", document.Text)
                )
            );
            return xdoc.ToString();
        }

    }
}
