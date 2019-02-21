using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexTextParser;

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
        public void CondenseRangesExpectedBehavior()
        {

        }
    }
}
