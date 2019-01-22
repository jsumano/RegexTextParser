using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegexTextParser;

namespace RegexTextParserTests
{
    public class ExpressionTestCase
    {
        public string Pattern { get; }
        public Range[] Ranges { get; }

        public ExpressionTestCase(string pattern, Range[] range)
        {
            Pattern = pattern;
            Ranges = range;
        }
    }
}
