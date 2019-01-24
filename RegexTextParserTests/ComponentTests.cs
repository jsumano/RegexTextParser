using System;
using System.Collections.Generic;
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
            List<CharSet> sets = new List<CharSet>
            {
                new CharSet("abcdefg"),
                new CharSet("1234567"),
                new CharSet("")
            };
        }
    }
}
