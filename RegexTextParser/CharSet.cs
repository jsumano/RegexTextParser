using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{

    public class CharSet
    {
        public List<string> Characters { get; }

        /// <summary>
        /// Represents a set of letters and numbers.
        /// </summary>
        /// <param name="text">A string containing literals and ranges to be added to the CharSet.</param>
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
                result.AddRange(StringFunction.ExtractRanges(ref text));
            }
            foreach (char letter in text)
            {
                string l = letter.ToString();
                if (!result.Contains(l))
                    result.Add(l);
            }
            return result;
        }

        public bool Contains(string text)
        {
            return Characters.Contains(text);
        }

    }
}
