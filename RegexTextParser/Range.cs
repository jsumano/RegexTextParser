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

        public static Range[] CondenseRanges(List<Range> range)
        {
            if (range.Count() < 2)
                return range.ToArray();
            return null;
        }

        public bool IsAdjacent(Range r1, Range r2)
        {
            // Adjacent
            if (r1.Left - 1 == r2.Left || r1.Left - 1 == r2.Right)
                return true;
            if (r1.Right + 1 == r2.Left || r1.Right + 1 == r2.Right)
                return true;
            // Left element of r2 overlaps r1.
            if (r1.Left <= r2.Left && r1.Right >= r2.Left)
                return true;
            // Right element of r2 overlaps r1.
            if (r1.Left <= r2.Right && r1.Right >= r2.Right)
                return true;
            return false;
        }

    }
}
