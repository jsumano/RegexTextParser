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
            string[] text = new string[]
            {
                "abcdefg",
                "1234567",
                "-12345",
                "123454-",
                "-abcdefg",
                "abcdefg-",
                "&*(^^*)-%*@!&*)%",
                "*()fhdsjkPIUHGDFu1543789"
            };
            List<CharSet> sets = new List<CharSet>();
            foreach (string s in text)
                sets.Add(new CharSet(s));
            for (int i = 0; i < text.Length; i++)
                Assert.AreEqual(text[i], string.Join("", sets[i].Characters.ToArray()));
        }
    }
}
