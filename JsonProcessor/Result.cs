using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonProcessor
{
    class Result
    {
        public string unescapedUrl { get; set; }
        public string cacheUrl { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        
        public string titleNoFormatting { get; set; }
    }
}
