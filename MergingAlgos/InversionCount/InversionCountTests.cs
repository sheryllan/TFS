using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace InversionCount
{
    [TestFixture]
    public class InversionCountTests
    {
        private Solution _solution;

        [OneTimeSetUp]
        public void Init()
        {
            _solution = new Solution();
        }

        [Test]
        public void GetCeillingInteger()
        {
            int part = 9;
            int ceilling = (int) Math.Ceiling((double)part / 2);
            Assert.AreEqual(5, ceilling);
        }

        [Test]
        public void OneElementOrAllEqualElementInput()
        {
            int[] A1 = new[] {24};
            int[] A2 = new[] {1, 1, 1, 1, 1, 1, 1};
            Assert.AreEqual(0, _solution.BottomUpInversions(A1));
            Assert.AreEqual(0, _solution.BottomUpInversions(A2));

            Assert.AreEqual(0, _solution.TopDownInversions(A1, 0, A1.Length - 1));
            Assert.AreEqual(0, _solution.TopDownInversions(A2, 0, A2.Length - 1));
        }

        [Test]
        public void NoEqualElementInput()
        {
            int[] A1 = new[] {32, 34, 33, 2, 5, 100};
            int[] A2 = new[] {7, 6, 5, 4, 3, 2, 1};
            Assert.AreEqual(7, _solution.BottomUpInversions(A1));
            Assert.AreEqual(21, _solution.BottomUpInversions(A2));

            Assert.AreEqual(7, _solution.TopDownInversions(A1, 0, A1.Length - 1));
            Assert.AreEqual(21, _solution.TopDownInversions(A2, 0, A2.Length - 1));
        }

        [Test]
        public void SomeEqualElementInput()
        {
            int[] A1 = new[] { 3, 3, 3, 2, 5, 10, 11, 11, 13 };
            int[] A2 = new[] { 2, 6, 5, 1, 3, 2, 1 };
            Assert.AreEqual(3, _solution.BottomUpInversions(A1));
            Assert.AreEqual(14, _solution.BottomUpInversions(A2));

            Assert.AreEqual(3, _solution.TopDownInversions(A1, 0, A1.Length - 1));
            Assert.AreEqual(14, _solution.TopDownInversions(A2, 0, A2.Length - 1));
        }
    }
}