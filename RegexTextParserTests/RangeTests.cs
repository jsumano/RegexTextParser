using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexTextParser;
using System.Linq;

namespace RegexTextParserTests
{
    [TestClass]
    public class RangeTests
    {

        [TestMethod]
        public void IsAdjacentValidAdjacentRangesReturnsTrue()
        {
            Range baseCase = new Range(5, 15);
            Range[] testCases = new Range[]
            {
                new Range(2,4),
                new Range(6, 10),
                new Range(16, 20),
                new Range(1, 20),
                new Range(1, 10),
                new Range(7, 20)
            };
            foreach (Range testCase in testCases)
                Assert.IsTrue(Range.IsAdjacent(baseCase, testCase));
        }

        [TestMethod]
        public void IsAdjacentInvalidDisjointRangesReturnsFalse()
        {
            Range baseCase = new Range(5, 15);
            Range[] testCases = new Range[]
            {
                new Range(1,3),
                new Range(17, 20),
                new Range(20, 50)
            };
            foreach (Range testCase in testCases)
                Assert.IsFalse(Range.IsAdjacent(baseCase, testCase));
        }

        [TestMethod]
        public void MergeRangesAdjacentReturnsMerged()
        {
            Range baseCase = new Range(5, 15);
            Range[] testCases = new Range[]
            {
                new Range(2, 4),
                new Range(6, 10),
                new Range(16, 20),
                new Range(1, 20),
                new Range(1, 10),
                new Range(7, 20)
            };
            Range[] expected = new Range[]
            {
                new Range(2, 15),
                new Range(5, 15),
                new Range(5, 20),
                new Range(1, 20),
                new Range(1, 15),
                new Range(5, 20)
            };
            for (int i = 0; i < testCases.Length; i++)
            {
                Range actual = Range.MergeRanges(baseCase, expected[i]);
                Assert.AreEqual(expected[i].Left, actual.Left);
                Assert.AreEqual(expected[i].Right, actual.Right);
            }
        }

        [TestMethod]
        public void MergeRangesDisjointedReturnsNull()
        {
            Range baseCase = new Range(5, 15);
            Range[] testCases = new Range[]
            {
                new Range(1,3),
                new Range(17, 20),
                new Range(20, 50)
            };

            for (int i = 0; i < testCases.Length; i++)
                Assert.IsNull(Range.MergeRanges(baseCase, testCases[i]));
        }

        [TestMethod]
        public void CondenseRangesAllAdjacentReturnsSingleCondensedRange()
        {
            Range[] uncondensed = new Range[]
            {
                new Range(80, 90), new Range(30, 39), new Range(1, 29), new Range(40, 60), new Range(61, 79), new Range(90, 100)
            };

            Range[] expected = new Range[] { new Range(1, 100) };

            Range[] actual = Range.CondenseRanges(uncondensed);
            for(int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected[i].Left, actual[i].Left);
                Assert.AreEqual(expected[i].Right, actual[i].Right);
            }
        }

        [TestMethod]
        public void CondenseRangesAllDisjunctReturnsInput()
        {
            Range[] uncondensed = new Range[]
            {
                new Range(80, 90), new Range(30, 35), new Range(1, 22), new Range(40, 60), new Range(63, 74), new Range(96, 100)
            };

            Range[] expected = uncondensed;

            Range[] actual = Range.CondenseRanges(uncondensed);
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected[i].Left, actual[i].Left);
                Assert.AreEqual(expected[i].Right, actual[i].Right);
            }
        }

        [TestMethod]
        public void CondenseRangesMixedInputReturnsCondensedandInput()
        {
            Range[] uncondensed = new Range[]
            {
                new Range(80, 90), new Range(30, 39), new Range(1, 29), new Range(40, 50), new Range(61, 75), new Range(90, 100)
            };

            Range[] expected = new Range[] { new Range(80, 100), new Range(1, 50), new Range(61, 75) };

            Range[] actual = Range.CondenseRanges(uncondensed);
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected[i].Left, actual[i].Left);
                Assert.AreEqual(expected[i].Right, actual[i].Right);
            }
        }

    }
}
