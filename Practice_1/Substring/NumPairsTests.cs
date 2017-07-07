using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Substring
{
    [TestClass]
    public class NumPairsTests
    {
        private NumPair _numPair;

        [TestInitialize]
        public void Init()
        {
            _numPair = new NumPair();
        }
        [TestMethod]
        public void InputWithEqualElements()
        {
            int[] a1 = new[] {0, 1, -3, 5, 0, 2, -1, 2, 0};
            Assert.AreEqual(4, _numPair.Solution(a1, 0));
            Assert.AreEqual(5, _numPair.Solution(a1, -1));
        }

        [TestMethod]
        public void InputWithoutEqualElements()
        {
            int[] a1 = new[] { 0, 1, -3, 5, 2, -1, -4};
            Assert.AreEqual(2, _numPair.Solution(a1, -4));
            Assert.AreEqual(0, _numPair.Solution(a1, -8));
        }

        [TestMethod]
        public void IntOverflow()
        {
            int[] a1 = new[] {int.MaxValue, int.MaxValue, 1, 0, 2, -1};
            int[] a2 = new[] {int.MinValue, 3, 0, -1, -1, 0, -1};
            Assert.AreEqual(2, _numPair.Solution(a1, int.MaxValue));
            Assert.AreEqual(0, _numPair.Solution(a1, int.MinValue));
            Assert.AreEqual(1, _numPair.Solution(a1, 0));
            Assert.AreEqual(0, _numPair.Solution(a2, int.MaxValue));
            Assert.AreEqual(2, _numPair.Solution(a2, int.MinValue));
            Assert.AreEqual(3, _numPair.Solution(a2, 2));
        }

        [TestMethod]
        public void OverflowVerification()
        {
            int min = unchecked(int.MaxValue + 1); 
            int max = unchecked(int.MinValue - 1); 
            int one = unchecked(int.MinValue - int.MaxValue);
            int minus_1 = unchecked(int.MaxValue - int.MinValue);
            int minus_2 = unchecked(int.MaxValue + int.MaxValue);
            int zero = unchecked(int.MinValue + int.MinValue);
            
            // ofInt(Max + c) = Min - 1 + c
            int min1Plus9 = unchecked (int.MaxValue + 10);

            // ofInt(Min - c) = Max + 1 - c
            int maxMinus4 = unchecked(int.MinValue - 5);

            Assert.AreEqual(int.MinValue, min);
            Assert.AreEqual(int.MaxValue, max);
            Assert.AreEqual(1, one);
            Assert.AreEqual(-1, minus_1);
            Assert.AreEqual(-2, minus_2);
            Assert.AreEqual(0, zero);

            Assert.AreEqual(int.MinValue + 9, min1Plus9);
            Assert.AreEqual(int.MaxValue - 4, maxMinus4);
        }
    }
}
