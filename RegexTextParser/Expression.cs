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

            for(int i = 0; i < text.Length; i++)
            {
                if (i > text.Length - 1 - target.Length)
                    break;


            }
        }
    }
}
