using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Service
{
    public interface IDocumentReader
    {
        public string ReadFile(string path);
    }
}
