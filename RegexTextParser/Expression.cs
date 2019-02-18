using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public static class Expression
    {

        public static Range[] MinMax(string text, Pattern[] pattern, int min, int max = -1)
        {
            // TODO complete implementation. Migrate common pattern matching functions to separate methods.
            // Change for loop conditional to i < text.Length - minimum pattern length.
            List<Range> result = new List<Range>();
            for(int i = 0; i < text.Length; i++)
            {
                foreach(Pattern p in pattern)
                {
                    bool match = false;
                    if (p.Type == PatternType.Literal)
                        match = p.Match(new string[] { text.Substring(i, p.GetLiteralLength()) });
                    else
                    {

                    }
                    if (!match)
                        break;
                }
            }
            return null; // fix
        }
    }
}
