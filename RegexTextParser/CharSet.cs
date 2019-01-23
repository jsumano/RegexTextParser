using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public class CharSet
    {
        public List<char> Characters { get; }

        public CharSet(string text)
        {
            Characters = GetCharacters(text);
        }


        private List<char> GetCharacters(string s)
        {
            List<char> result = new List<char>();
            string text = s;
            if (text.Contains('-'))
            {
                result.AddRange(ExtractRanges(ref text));
            }
        }

        private List<char> ExtractRanges(ref string text)
        {
            List<char> result = new List<char>();
            List<char> letters = text.ToList();
            while (letters.Contains('-'))
            {
                int index = 0;
                while (letters[index] != '-') index++;
                int left = index - 1;
                int right = index + 1;
                string start = "";
                string end = "";
                if (Char.IsNumber(letters[left]))
                {
                    start = letters[left].ToString();
                    end = letters[right].ToString();
                    left--;
                    right++;
                    while (left > 0 && Char.IsNumber(letters[left]))
                    {
                        start = letters[left] + start;
                        left--;
                    }
                    while (right < text.Count() - 1 && Char.IsNumber(letters[right]))
                    {
                        end += letters[right];
                        right++;
                    }
                }
                result.AddRange(GetRanges(start, end));
                int count = (left == 0) ? right + 1 : right - left + 1; 
                letters.RemoveRange(left, count);
            }
            text = letters.ToString();
            return result;
        }

        private List<char> GetRanges(string left, string right)
        {

        }

    }
}
