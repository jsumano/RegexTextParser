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
        public void SameStringValidInputReturnTrue()
        {
            bool[] testCases = new bool[]
            {
                StringFunction.SameLetter('a', 'A'),
                StringFunction.SameLetter('Q', 'q'),
                StringFunction.SameLetter('T', 'T'),
                StringFunction.SameLetter('x', 'x'),
                StringFunction.SameLetter('B', 'b'),
                StringFunction.SameLetter('u', 'U')
            };

            foreach (bool test in testCases)
                Assert.IsTrue(test);
        }

        [TestMethod]
        public void SameStringInvalidInputReturnFalse()
        {
            bool[] testCases = new bool[]
            {
                StringFunction.SameLetter('g', 'A'),
                StringFunction.SameLetter('Q', 'i'),
                StringFunction.SameLetter('T', 'n'),
                StringFunction.SameLetter('x', 'y'),
                StringFunction.SameLetter('B', 'l'),
                StringFunction.SameLetter('u', 'W')
            };

            foreach (bool test in testCases)
                Assert.IsFalse(test);
        }

        [TestMethod]
        public void IsAlphaValidInputReturnTrue()
        {
            char[] letters = new char[]
            {
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            foreach (char letter in letters)
                Assert.IsTrue(StringFunction.IsAlpha(letter));
        }

        [TestMethod]
        public void IsAlphaInvalidInputReturnFalse()
        {
            char[] letters = new char[]
            {
                '`','~','!','@','#','$','%','^','&','*','(',')','_','+','`','1','2','3','4','5','6','7','8','9','0','-',
                '=', '{', '}', ':', '"', '|', '<', '>', '?', '[', ']', ';', '\'', '\\', ',', '.', '/'
            };

            foreach (char letter in letters)
                Assert.IsFalse(StringFunction.IsAlpha(letter));
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
