using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public static class Expression
    {

        public static Range[] Plus(string text, string target)
        {
            if (!text.Contains(target))
                return null;

            List<Range> list = new List<Range>();
            for (int i = 0; i < text.Length; i++)
            {
                if (i > text.Length - 1 - target.Length)
                    break;

                if (text.Substring(i, target.Length) == target)
                    list.Add(new Range(i, i + target.Length));
            }
            return list.ToArray();
        }
    }
}
