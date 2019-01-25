﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public class CharSet
    {
        public List<string> Characters { get; }
        

        public CharSet(string text)
        {
            Characters = GetCharacters(text);
        }


        private List<string> GetCharacters(string s)
        {
            List<string> result = new List<string>();
            string text = s;
            if (text.Contains('-'))
            {
                result.AddRange(ExtractRanges(ref text));
            }
            foreach (char letter in text)
                result.Add(letter.ToString());
            return result;
        }

        

    }
}
