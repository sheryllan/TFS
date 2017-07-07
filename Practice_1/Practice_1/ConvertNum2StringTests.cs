using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practice_1
{
    [TestClass]
    public class ConvertNum2StringTests
    {
        [TestMethod]
        public void TestRangeZeroToBillion()
        {
            ConvertNum2String convert = new ConvertNum2String();
            int num1 = 284930;
            int num2 = 1000000000;
            long num3 = 9000000000;
            int num4 = 39;
            int num5 = 543;
            int num6 = 4820;
            int num7 = 12000215;
            int num8 = 0;

            Assert.AreEqual("Two Hundred Eighty Four Thousand Nine Hundred Thirty", convert.Num2String(num1));
            Assert.AreEqual("One Billion", convert.Num2String(num2));
            Assert.AreEqual("Nine Billion", convert.Num2String(num3));
            Assert.AreEqual("Thirty Nine", convert.Num2String(num4));
            Assert.AreEqual("Five Hundred Fourty Three", convert.Num2String(num5));
            Assert.AreEqual("Four Thousand Eight Hundred Twenty", convert.Num2String(num6));
            Assert.AreEqual("Twelve Million Two Hundred Fifteen", convert.Num2String(num7));
            Assert.AreEqual("Zero", convert.Num2String(num8));
        }

        [TestMethod]
        public void TestStringIsEmptyOrNull()
        {
            string s = "";
            Assert.IsTrue(string.IsNullOrEmpty(s));
        }
        
    }
}
