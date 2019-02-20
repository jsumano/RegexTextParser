using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexTextParser;

namespace RegexTextParserTests
{
    [TestClass]
    public class PatternTests
    {
        [TestMethod]
        public void CreateCharSetWithLiterals()
        {
            List<string> expected = new List<string>
            {
                "a","b","c","D","E","F","G","1","2","3"
            };

            CharSet charSet = new CharSet("abcDEFG123");
            Assert.IsTrue(expected.SequenceEqual(charSet.Characters));
        }

        [TestMethod]
        public void CreateCharSetWithRanges()
        {
            List<string> expected = new List<string>
            {
                "a","b","c","D","E","F","G","1","2","3"
            };

            CharSet charSet = new CharSet("a-cD-G1-3");
            Assert.IsTrue(expected.SequenceEqual(charSet.Characters));
        }

        [TestMethod]
        public void CreateCharSetWithRangesandLiterals()
        {
            List<string> expected = new List<string>
            {
                "D","E","F","G","a","b","c","1","2","3"
            };

            CharSet charSet = new CharSet("abcD-G123");
            Assert.IsTrue(expected.SequenceEqual(charSet.Characters));
        }

        [TestMethod]
        public void PatternMatchLiteralReturnTrue()
        {
            Pattern pattern = new Pattern("abcdEFGH1234");
            string[] expMatch = { "abcdEFGH1234" };
            Assert.IsTrue(pattern.Match(expMatch));
        }

        [TestMethod]
        public void PatternMatchCharSetReturnTrue()
        {
            Pattern pattern = new Pattern(new CharSet("a-dE-H1-4"));
            string[] expMatch = { "a","b","c","d","E","F","G","H","1","2","3","4" };
            Assert.IsTrue(pattern.Match(expMatch));
        }

        [TestMethod]
        public void PatternNoMatchLiteralReturnFalse()
        {
            Pattern pattern = new Pattern("abcdEFGH1234");
            string[] expMatch = { "abcdEFGH12345" };
            Assert.IsFalse(pattern.Match(expMatch));
        }

        [TestMethod]
        public void PatternNoMatchCharSetReturnFalse()
        {
            Pattern pattern = new Pattern(new CharSet("a-dE-H1-4"));
            string[] expMatch = { "a", "b", "c", "d", "E", "F", "G", "H", "1", "2", "3", "4", "5" };
            Assert.IsFalse(pattern.Match(expMatch));
        }

        [TestMethod]
        public void GetLastCharSetMatchIndexExpected()
        {
            Pattern cPattern = new Pattern(new CharSet("a-e5"));
            string text = "jkl432ace5nmnm";
            Assert.AreEqual(6, cPattern.GetLastCharSetMatchIndex(text));
        }
    }
}
