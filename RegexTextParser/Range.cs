using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTextParser
{
    public class Range
    {

        public int Left { get; }
        public int Right { get; }

        public Range(int left, int right)
        {
            if (left > right)
                throw new ArgumentOutOfRangeException();

            Left = left;
            Right = right;
        }
    }
}
