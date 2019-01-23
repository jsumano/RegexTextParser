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

        private List<string> ExtractRanges(ref string text)
        {
            List<string> result = new List<string>();
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

        private List<string> GetRanges(string left, string right)
        {
            List<string> result = new List<string>();
            if (Char.IsNumber(left[0]))
            {
                int start = Convert.ToInt32(left);
                int end = Convert.ToInt32(right);
                for (int i = start; i <= end; i++)
                    result.Add(i.ToString());
                return result;
            }
            char l = '\0';
            char r = '\0';

            if (!Char.TryParse(left, out l) || !Char.TryParse(right, out r))
                throw new ArgumentException();
            if (Char.IsUpper(l) != Char.IsUpper(r))
                throw new ArgumentException();


        }

    }
}
