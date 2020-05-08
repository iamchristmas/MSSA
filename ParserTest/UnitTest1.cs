using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVParser;

namespace ParserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCCSVTest1()
        {
            string test = "\"a,b\",c";
            List<string> output = new List<string>{"a,b","c"};

            List<string> testList = Parser.GetCSV(test);

            CollectionAssert.AreEqual(output, testList);
        }
    }
}
