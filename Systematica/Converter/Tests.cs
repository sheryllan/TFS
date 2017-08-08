using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Converter
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestInToText()
        {
            int case1 = 0;
            int case2 = -9;
            int case3 = 21;
            int case4 = -93000;
            int case5 = Int32.MinValue;
            int case6 = Int32.MaxValue;

            TextConverter converter = new TextConverter();
            Assert.AreEqual("0", converter.inToText(case1));
            Assert.AreEqual("-9", converter.inToText(case2));
            Assert.AreEqual("21", converter.inToText(case3));
            Assert.AreEqual("-93000", converter.inToText(case4));
            Assert.AreEqual("-2147483648", converter.inToText(case5));
            Assert.AreEqual("2147483647", converter.inToText(case6));

        }

    }
}
