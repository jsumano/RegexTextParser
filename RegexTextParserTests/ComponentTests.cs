using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexTextParser;

namespace RegexTextParserTests
{
    [TestClass]
    public class ComponentTests
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
    }
}
