using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonProcessor
{
    class Results
    {
        public IEnumerable<Result> results { get; set; }
        public Cursor cursor { get; set; }
    }
}
