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
    }
}
