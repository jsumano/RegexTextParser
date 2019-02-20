﻿using System;
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

        /// <summary>
        /// Condenses array of Ranges by merging any adjacent Ranges.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static Range[] CondenseRanges(Range[] range)
        {
            if (range.Count() < 2)
                return range.ToArray();
            return null;

            Range current = range[0];
            for(int i =1; i < range.Count();i++)
            {

            }
        }

        /// <summary>
        /// Merges two adjacent Ranges.
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static Range MergeRanges(Range r1, Range r2)
        {
            if (!IsAdjacent(r1, r2))
                return null;
            Range[] combined = new Range[] { r1, r2 };
            int min = int.MaxValue;
            int max = -1;
            foreach(Range r in combined)
            {
                if (r.Left < min)
                    min = r.Left;
                if (r.Right > max)
                    max = r.Right;
            }
            return new Range(min, max);
        }

        public static bool IsAdjacent(Range r1, Range r2)
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
            // Left element of r1 overlaps r2.
            if (r2.Left <= r1.Left && r2.Right >= r1.Left)
                return true;
            // Right element of r1 overlaps r2.
            if (r2.Left <= r1.Right && r2.Right >= r1.Right)
                return true;
            return false;
        }

    }
}
