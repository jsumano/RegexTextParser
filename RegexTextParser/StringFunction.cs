using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public static class StringFunction
    {
        static readonly char[] alpha = new char[]
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };

        public static List<string> ExtractRanges(ref string text)
        {
            List<string> result = new List<string>();
            List<char> letters = text.ToList();
            while (letters.Contains('-'))
            {
                int index = 0;
                while (letters[index] != '-') index++;
                int left = index - 1;
                int right = index + 1;
                if (left < 0 || right > letters.Count - 1)
                {
                    result.Add(letters[index].ToString());
                    letters.RemoveAt(index);
                    continue;
                }
                string start = letters[left].ToString();
                string end = letters[right].ToString();
                if (Char.IsNumber(letters[left]) && Char.IsNumber(letters[right]))
                {
                    while (left > 0 && Char.IsNumber(letters[left - 1]))
                    {
                        left--;
                        start = letters[left] + start;
                    }
                    while (right < letters.Count() - 1 && Char.IsNumber(letters[right + 1]))
                    {
                        right++;
                        end += letters[right];
                    }
                }
                if (IsValidRange(start, end))
                {
                    result.AddRange(EnumerateFromRange(start, end));
                    letters.RemoveRange(left, right - left + 1);
                }
                else
                {
                    result.Add(letters[index].ToString());
                    letters.RemoveAt(index);
                }
            }
            text = "";
            foreach (char letter in letters)
                text += letter;
            return result;
        }


        public static bool IsValidRange(string start, string end)
        {
            bool numeric = IsNumeric(start);
            if (numeric != IsNumeric(end))
                return false;
            if (Char.IsUpper(start[0]) != Char.IsUpper(end[0]))
                return false;
            if (numeric)
            {
                int low = Convert.ToInt32(start);
                int high = Convert.ToInt32(end);
                return low < high;
            }
            // alpha
            char left = '\0';
            char right = '\0';
            if (!Char.TryParse(start, out left) || !Char.TryParse(end, out right))
                return false;
            if (!Char.IsLetter(left) || !Char.IsLetter(right))
                return false;
            if (SameLetter(left, right))
                return false;
            for (int i = 0; i < alpha.Length; i++)
            {
                if (SameLetter(alpha[i], right))
                    return false;
                else if (SameLetter(alpha[i], left))
                    return true;
            }
            return false;
        }

        

        public static bool SameLetter(char l1, char l2)
        {
            char c1 = l1;
            char c2 = l2;
            int cap1 = Char.IsUpper(l1) ? 1 : 0;
            int cap2 = Char.IsUpper(l2) ? 1 : 0;
            if (cap1 > cap2)
                c2 = Char.ToUpper(c2);
            else if (cap1 < cap2)
                c1 = Char.ToUpper(c1);
            return c1 == c2;
        }


        public static bool IsNumeric(string num)
        {
            foreach (char c in num)
            {
                if (!Char.IsNumber(c))
                    return false;
            }
            return true;
        }

        public static List<string> EnumerateFromRange(string left, string right)
        {
            if (!IsValidRange(left, right))
                return null;

            List<string> result = new List<string>();
            if (IsNumeric(left))
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

            bool found = false;
            for (int i = 0; i < alpha.Length; i++)
            {
                if (SameLetter(alpha[i], l))
                    found = true;
                if (!found)
                    continue;
                if (Char.IsUpper(l))
                    result.Add(Char.ToUpper(alpha[i]).ToString());
                else
                    result.Add(alpha[i].ToString());
                if (SameLetter(alpha[i], r))
                    break;
            }
            return result;
        }
    }
}
