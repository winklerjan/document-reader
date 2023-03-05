using DocumentReader.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader
{
    internal static class Helper
    {
        public static string GetFileFormat(string filename)
        {
            return new FileInfo(filename).Extension;
        }

        public static bool IsHttpSource(string path)
        {
            return path.StartsWith("http") || path.StartsWith("https");
        }
    }
}
