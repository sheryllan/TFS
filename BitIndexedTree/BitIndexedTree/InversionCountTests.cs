using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BitIndexedTree
{
    [TestFixture]
    class InversionCountTests
    {
        private InversionCount _inversionCount;
        [OneTimeSetUp]
        public void Init()
        {
            _inversionCount = new InversionCount();
        }

        [Test]
        public void OneElementOrAllEqualElementInput()
        {
            int[] A1 = new[] { 24 };
            int[] A2 = new[] { 1, 1, 1, 1, 1, 1, 1 };
            Assert.AreEqual(0, _inversionCount.Solution(A1));
            Assert.AreEqual(0, _inversionCount.Solution(A2));

            Assert.AreEqual(0, _inversionCount.Solution2(A1));
            Assert.AreEqual(0, _inversionCount.Solution2(A2));
        }

        [Test]
        public void NoEqualElementInput()
        {
            int[] A1 = new[] { 32, 34, 33, 2, 5, 100 };
            int[] A2 = new[] { 7, 6, 5, 4, 3, 2, 1 };
            Assert.AreEqual(7, _inversionCount.Solution(A1));
            Assert.AreEqual(21, _inversionCount.Solution(A2));

            Assert.AreEqual(7, _inversionCount.Solution2(A1));
            Assert.AreEqual(21, _inversionCount.Solution2(A2));
        }

        [Test]
        public void SomeEqualElementInput()
        {
            int[] A1 = new[] { 3, 3, 3, 2, 5, 10, 11, 11, 13 };
            int[] A2 = new[] { 2, 6, 5, 1, 3, 2, 1 };
            Assert.AreEqual(3, _inversionCount.Solution(A1));
            Assert.AreEqual(14, _inversionCount.Solution(A2));

            Assert.AreEqual(3, _inversionCount.Solution2(A1));
            Assert.AreEqual(14, _inversionCount.Solution2(A2));
        }
    }
}
