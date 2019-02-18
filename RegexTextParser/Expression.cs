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
            int minPatternLength = 0;
            foreach (Pattern pn in pattern)
                minPatternLength += pn.MinimumLength;
            List<Range> result = new List<Range>();
            for(int i = 0; i < text.Length; i++)
            {
                int index = i;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (index > text.Length - 1)
                        break;
                    bool match = false;
                    if (pattern[j].Type == PatternType.Literal)
                    {
                        match = pattern[j].Match(new string[] { text.Substring(index, pattern[j].GetLiteralLength()) });
                        index += pattern[j].GetLiteralLength();
                    }
                    else
                    {
                        int lastMatch = pattern[j].GetLastCharSetMatchIndex(text.Substring(index));
                        match = index != lastMatch || pattern[j].Match(new string[] { text[index].ToString() });
                        index = lastMatch + 1;
                    }
                    if (!match)
                        break;
                }
            }
            return null; // fix
        }
    }
}
