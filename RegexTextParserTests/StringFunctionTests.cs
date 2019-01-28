using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexTextParser;

namespace RegexTextParserTests
{
    [TestClass]
    public class StringFunctionTests
    {
        [TestMethod]
        public void IsValidRangeValidInputReturnTrue()
        {
            bool[] testRange = new bool[]
            {
                StringFunction.IsValidRange("1", "20"),
                StringFunction.IsValidRange("A", "Z"),
                StringFunction.IsValidRange("a", "z"),
            };

            foreach (bool test in testRange)
                Assert.IsTrue(test);
        }

        [TestMethod]
        public void IsValidRangeInvalidInputReturnFalse()
        {
            bool[] testRange = new bool[]
            {
                StringFunction.IsValidRange("1", "z"),
                StringFunction.IsValidRange("!", "?"),
                StringFunction.IsValidRange("x", "r"),
            };

            foreach (bool test in testRange)
                Assert.IsFalse(test);
        }


        [TestMethod]
        public void IsNumericStringValidInputReturnTrue()
        {
            string[] testCases = new string[] { "123", "7", "999", "11", "0", "865473" };
            foreach (string text in testCases)
                Assert.IsTrue(StringFunction.IsNumericString(text));
        }

        [TestMethod]
        public void IsNumericStringInvalidInputReturnFalse()
        {
            string[] testCases = new string[] { "123a", "!", "x", "1>1", "0|", "8654q73", "[]", "+", "-", "=" };
            foreach (string text in testCases)
                Assert.IsFalse(StringFunction.IsNumericString(text));
        }
    }
}
