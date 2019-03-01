using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public static class Expression
    {

        public static Range[] QuestionMark(string text, Pattern[] pattern)
        {
            return MinMax(text, pattern, 0, 1);
        }

        public static Range[] MinMax(string text, Pattern[] pattern, int min, int max = -1)
        {
            // TODO Migrate common pattern matching functions to separate methods.
            if (max != -1 && min > max)
                return null;
            if (text == null || pattern == null)
                return null;
            int minPatternLength = 0;
            foreach (Pattern pn in pattern)
                minPatternLength += pn.MinimumLength;
            List<Range> result = new List<Range>();
            List<Range> matchQueue = new List<Range>();
            for(int i = 0; i < text.Length - minPatternLength; i++)
            {
                int index = i;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (index > text.Length - 1)
                        break;
                    bool match = false;
                    // Pattern out of text bounds.
                    if (pattern[j].Type == PatternType.Literal && index + pattern[j].GetLiteralLength() > text.Length - 1)
                        break;
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
                    {
                        if (matchQueue.Count() >= min && (max == -1 || matchQueue.Count() <= max))
                            result.AddRange(matchQueue);
                        matchQueue.Clear();
                        break;
                    }
                    if (j == pattern.Length - 1)
                        matchQueue.Add(new Range(i, index - 1));
                }

                // Clear result if over max.
                if (max != -1 && matchQueue.Count() > max)
                {
                    result.Clear();
                    break;
                }
            }
            return Range.CondenseRanges(result.ToArray());
        }
    }
}
