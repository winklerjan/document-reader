using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Model
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public Document(string title, string text)
        {
            Text = text;
            Title = title;
        }
    }
}
