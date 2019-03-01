using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexTextParser;
using System.Collections.Generic;
using System.Linq;


namespace RegexTextParserTests
{
    [TestClass]
    public class ExpressionTests
    {

        [TestMethod]
        public void MinMaxValidMin1ValidMax1Throughn()
        {
            string text = "x xx xxx xxxx";

            Pattern[] pattern = new Pattern[] { new Pattern("x") };

            List<Range[]> expected = new List<Range[]>
            {
                new Range[] { new Range(0,0)},
                new Range[] { new Range(0,0), new Range(2,3)},
                new Range[] { new Range(0,0), new Range(2,3), new Range(5,7)},
                new Range[] { new Range(0,0), new Range(2,3), new Range(5,7), new Range(9,12)}
            };

            for (int i = 0; i < expected.Count; i++)
            {
                Range[] actual = Expression.MinMax(text, pattern, 1, i + 1);
                for (int j = 0; j < actual.Length; j++)
                {
                    Assert.AreEqual(expected[i][j].Left, actual[j].Left);
                    Assert.AreEqual(expected[i][j].Right, actual[j].Right);
                }

            }
        }

        [TestMethod]
        public void MinMaxValidMin1ThroughnValidMaxn()
        {
            string text = "x xx xxx xxxx";

            Pattern[] pattern = new Pattern[] { new Pattern("x") };

            List<Range[]> expected = new List<Range[]>
            {
                new Range[] { new Range(0,0), new Range(2,3), new Range(5,7), new Range(9,12)},
                new Range[] { new Range(2,3), new Range(5,7), new Range(9,12)},
                new Range[] { new Range(5,7), new Range(9,12)},
                new Range[] { new Range(9,12)},
            };

            for (int i = 0; i < expected.Count; i++)
            {
                Range[] actual = Expression.MinMax(text, pattern, i + 1, expected.Count);
                for (int j = 0; j < actual.Length; j++)
                {
                    Assert.AreEqual(expected[i][j].Left, actual[j].Left);
                    Assert.AreEqual(expected[i][j].Right, actual[j].Right);
                }

            }
        }

        [TestMethod]
        public void MinMaxValidMin0ValidMax0()
        {
            string text = "x xx xxx xxxx";

            Pattern[] pattern = new Pattern[] { new Pattern("x") };

            Range[] expected = new Range[0];
            Range[] actual = Expression.MinMax(text, pattern, 0, 0);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void MinMaxnullInputsReturnsnull()
        {
            string text = "x xx xxx xxxx";

            Pattern[] pattern = new Pattern[] { new Pattern("x") };

            Assert.IsNull(Expression.MinMax(null, pattern, 0, 0));
            Assert.IsNull(Expression.MinMax(text, null, 0, 0));
        }
    }
}
