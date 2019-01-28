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
                if (IsValidRange(start, end))
                {
                    result.AddRange(GetRanges(start, end));
                    int count = (left == 0) ? right + 1 : right - left + 1;
                    letters.RemoveRange(left, count);
                }
                else
                {
                    result.Add(letters[index].ToString());
                    letters.RemoveAt(index);
                }
            }
            text = letters.ToString();
            return result;
        }

        public static bool IsValidRange(string start, string end)
        {
            if (IsNumericString(start) != IsNumericString(end))
                return false;
            if (Char.IsUpper(start[0]) != Char.IsUpper(end[0]))
                return false;
            if (IsNumericString(start))
            {
                int low = Convert.ToInt32(start);
                int high = Convert.ToInt32(end);
                return low < high;
            }
            // alpha
            char left = '\0';
            char right = '\0';
            if (!IsAlpha(left) || !IsAlpha(right))
                return false;
            if (!Char.TryParse(start, out left) || !Char.TryParse(end, out right))
                return false;
            if (left == right)
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

        public static bool IsAlpha(char c)
        {
            if (!alpha.Contains(c) && !alpha.Contains(Char.ToLower(c)))
                return false;
            return true;
        }

        public static bool IsNumericString(string num)
        {
            foreach (char c in num)
            {
                if (!Char.IsNumber(c))
                    return false;
            }
            return true;
        }

        public static List<string> GetRanges(string left, string right)
        {
            List<string> result = new List<string>();
            if (IsNumericString(left))
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
                if (alpha[i] == l || Char.ToUpper(alpha[i]) == l)
                    found = true;
                if (!found)
                    continue;
                if (Char.IsUpper(l))
                    result.Add(Char.ToUpper(alpha[i]).ToString());
                else
                    result.Add(alpha[i].ToString());
            }
            return result;
        }
    }
}
