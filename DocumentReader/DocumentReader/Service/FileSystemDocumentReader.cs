using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Service
{
    public class FileSystemDocumentReader : IDocumentReader
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
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
