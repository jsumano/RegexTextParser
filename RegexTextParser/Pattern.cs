using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public class Pattern
    {
        public PatternType Type { get; }
        string literal;
        CharSet charSet;

        public Pattern(string text)
        {
            Type = PatternType.Literal;
            literal = text;
            charSet = null;
        }

        public Pattern(CharSet set)
        {
            Type = PatternType.CharSet;
            literal = null;
            charSet = set;
        }

        public bool Match(string[] text)
        {
            if (Type == PatternType.Literal)
                return literal.SequenceEqual(StringFunction.ArrayToString(text));
            else
            {
                foreach (string s in text)
                    if (!charSet.Contains(s)) return false;
                return true;
            }
        }
    }
}
