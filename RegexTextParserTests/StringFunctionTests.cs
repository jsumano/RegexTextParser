using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexTextParser;
using System.Collections.Generic;
using System.Linq;

namespace RegexTextParserTests
{
    [TestClass]
    public class StringFunctionTests
    {

        [TestMethod]
        public void ExtractRangesExpectedBehavior()
        {

            string text = "abcd7-11tyya-h224bI-M*()&-%$";
            string expectedText = "abcdtyy224b*()&%$";
            string expectedRanges = "7891011abcdefghIJKLM-";
            string actualRanges = "";
            List<string> ranges = StringFunction.ExtractRanges(ref text);
            foreach (string s in ranges)
                actualRanges += s;
            Assert.AreEqual(expectedText, text);
            Assert.AreEqual(expectedRanges, actualRanges);
        }

        [TestMethod]
        public void EnumerateFromRangeValidInputReturnList()
        {
            List<string>[] testCases = new List<string>[]
            {
                StringFunction.EnumerateFromRange("1", "10"),
                StringFunction.EnumerateFromRange("a", "z"),
                StringFunction.EnumerateFromRange("A", "Z"),
                StringFunction.EnumerateFromRange("a", "j"),
                StringFunction.EnumerateFromRange("k", "z"),
                StringFunction.EnumerateFromRange("A", "J"),
                StringFunction.EnumerateFromRange("K", "Z"),
            };

            List<string>[] expected = new List<string>[]
            {
                new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"},
                new List<string> { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" },
                new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" },
                new List<string> { "a","b","c","d","e","f","g","h","i","j" },
                new List<string> { "k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" },
                new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"},
                new List<string> { "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" },
            };

            for (int i = 0; i < testCases.Length; i++)
                Assert.IsTrue(expected[i].SequenceEqual(testCases[i]));
        }

        [TestMethod]
        public void EnumerateFromRangeInvalidInputReturnNull()
        {
            List<string>[] testCases = new List<string>[]
            {
                StringFunction.EnumerateFromRange("1", "z"),
                StringFunction.EnumerateFromRange("a", "7"),
                StringFunction.EnumerateFromRange("~", "?"),
                StringFunction.EnumerateFromRange("z", "r"),
                StringFunction.EnumerateFromRange("a", "Z"),
                StringFunction.EnumerateFromRange("A", "z"),
                StringFunction.EnumerateFromRange("1", "@"),
                StringFunction.EnumerateFromRange("q", "*")
            };

            foreach (List<string> test in testCases)
                Assert.AreEqual(null, test);
        }


        [TestMethod]
        public void IsValidRangeValidInputReturnTrue()
        {
            bool[] testRange = new bool[]
            {
                StringFunction.IsValidRange("1", "20"),
                StringFunction.IsValidRange("A", "Z"),
               StringFunction.IsValidRange("a", "z")
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
                StringFunction.IsValidRange("a", "7"),
                StringFunction.IsValidRange("~", "?"),
                StringFunction.IsValidRange("z", "r"),
                StringFunction.IsValidRange("a", "Z"),
                StringFunction.IsValidRange("A", "z"),
                StringFunction.IsValidRange("1", "@"),
                StringFunction.IsValidRange("q", "*")
            };

            foreach (bool test in testRange)
                Assert.IsFalse(test);
        }

        [TestMethod]
        public void SameLetterValidInputReturnTrue()
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
        public void SameLetterInvalidInputReturnFalse()
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
        public void IsNumericStringValidInputReturnTrue()
        {
            string[] testCases = new string[] { "123", "7", "999", "11", "0", "865473" };
            foreach (string text in testCases)
                Assert.IsTrue(StringFunction.IsNumeric(text));
        }

        [TestMethod]
        public void IsNumericStringInvalidInputReturnFalse()
        {
            string[] testCases = new string[] { "123a", "!", "x", "1>1", "0|", "8654q73", "[]", "+", "-", "=" };
            foreach (string text in testCases)
                Assert.IsFalse(StringFunction.IsNumeric(text));
        }

        [TestMethod]
        public void GetAdjacentNumbersLeftInclusive()
        {
            string[] test = 
            {
                "1234hjklp;56778",
                "adfjklfds1k2j3k4",
                "1k2j3h"
            };

            List<string[]> exResults = new List<string[]>
            {
                new string[] { "1", "12", "123", "1234" },
                new string[] { },
                new string[] {"1"}
            };

            for(int i = 0; i < test.Length; i++)
                Assert.IsTrue(exResults[i].SequenceEqual(StringFunction.GetAdjacentNumbersLeftInclusive(test[i])));
        }


    }
}
