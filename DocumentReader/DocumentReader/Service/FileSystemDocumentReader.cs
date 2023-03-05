using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Service
{
    internal class FileSystemDocumentReader : IDocumentReader
    {
        public string ReadFile(string path)
        {

            try
            {
                using (FileStream sourceStream = File.Open(path, FileMode.Open))
                {
                    StreamReader reader = new StreamReader(sourceStream);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                // TODO throw more detailed exceptions
                throw new Exception(ex.Message);
            }

        }
    }
}
