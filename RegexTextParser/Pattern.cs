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

        public int GetLiteralLength()
        {
            if (Type == PatternType.Literal)
                return literal.Length;
            return -1;
        }

        public int GetLastCharSetMatchIndex(string text)
        {
            if (Type != PatternType.CharSet)
                return -1;
            int last = 0;
            int increment = 1;
            for (int i = 0; i < text.Length; i += increment)
            {
                increment = 1;
                bool match = false;
                // Check all possible contiguous numbers and use the largest match.
                if (Char.IsNumber(text[i]))
                {
                    string[] conNumbers = StringFunction.GetAdjacentNumbersLeftInclusive(text.Substring(i));
                    foreach(string num in conNumbers)
                    {
                        if(charSet.Contains(num))
                        {
                            match = true;
                            increment = num.Length;
                        }
                    }
                }
                else
                {
                    match = charSet.Contains(text[i].ToString());
                }
                if (!match)
                    break;
                else
                    last = i;
            }
            return last;
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
