using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Substring
{
    [TestClass]
    public class LongestSubstringTests
    {
        private LongestSubstring _longestSubstring;
        [TestInitialize]
        public void Init()
        {
            _longestSubstring = new LongestSubstring();
        }

        [TestMethod]
        public void LongestSubstringAtBeginning()
        {
            string s1 = "eeeeee33555kkk";
            string s2 = "44444iiiss4444jii";
            Assert.AreEqual(new Tuple<int,int>(0,6), _longestSubstring.Solution(s1));
            Assert.AreEqual(new Tuple<int, int>(0, 5), _longestSubstring.Solution(s2));
        }

        [TestMethod]
        public void LongestSubstringInMiddle()
        {
            string s1 = "aabbbbbbbkkkkkcccc"; // without recurring elements
            string s2 = "111001111220111"; // with recurring elements
            Assert.AreEqual(new Tuple<int, int>(2, 7), _longestSubstring.Solution(s1));
            Assert.AreEqual(new Tuple<int, int>(5, 4), _longestSubstring.Solution(s2));

        }

        [TestMethod]
        public void LongestSubstringAtEnd()
        {
            string s1 = "000111122222"; // without recurring elements
            string s2 = "cccddddccdddddd"; // with recurring elements
            Assert.AreEqual(new Tuple<int, int>(7, 5), _longestSubstring.Solution(s1));
            Assert.AreEqual(new Tuple<int, int>(9, 6), _longestSubstring.Solution(s2));
        }

        [TestMethod]
        public void EdgeCaseString()
        {
            string s1 = "";
            string s2 = "fffffffff";

            Assert.AreEqual(new Tuple<int, int>(0,0), _longestSubstring.Solution(s1));
            Assert.AreEqual(new Tuple<int, int>(0,9), _longestSubstring.Solution(s2));
        }
    }
}
