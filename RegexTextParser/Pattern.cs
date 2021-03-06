﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public class Pattern
    {
        public PatternType Type { get; }
        public int MinimumLength { get; }
        string literal;
        CharSet charSet;

        public Pattern(string text)
        {
            Type = PatternType.Literal;
            MinimumLength = text.Length;
            literal = text;
            charSet = null;
        }

        public Pattern(CharSet set)
        {
            Type = PatternType.CharSet;
            MinimumLength = 1;
            literal = null;
            charSet = set;
        }

        /// <summary>
        /// Returns the length of the literal value.
        /// </summary>
        /// <returns></returns>
        public int GetLiteralLength()
        {
            if (Type == PatternType.Literal)
                return literal.Length;
            return -1;
        }

        /// <summary>
        /// Returns the starting index of the last CharSet match in the string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetLastCharSetMatchIndex(string text)
        {
            if (Type != PatternType.CharSet)
                return -1;
            int last = -1;
            int increment = 1;
            bool lastMatched = false;
            for (int i = 0; i < text.Length; i += increment)
            {
                increment = 1;
                bool match = false;
                // Check all possible contiguous numbers and use the largest match.
                if (Char.IsNumber(text[i]))
                {
                    string[] conNumbers = StringFunction.GetAdjacentNumbersLeftInclusive(text.Substring(i));
                    foreach (string num in conNumbers)
                    {
                        if (charSet.Contains(num))
                        {
                            match = true;
                            increment = num.Length;
                        }
                    }
                }
                else if (charSet.Contains(text[i].ToString()))
                    match = true;
                if (match && !lastMatched)
                    last = i;
                if (match)
                    lastMatched = true;
                else
                    lastMatched = false;
            }
            return last;
        }

        /// <summary>
        /// Checks if the string array matches the pattern.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
