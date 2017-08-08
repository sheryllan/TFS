using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heap
{
    [TestClass]
    public class BinaryHeapTests
    {
        private BinaryHeap _bh;

        [TestInitialize]
        public void Init()
        {
            _bh = new BinaryHeap();
        }

        [TestMethod]
        public void HeapifyWithoutEqualElements()
        {
            int[] a1 = {4, 10, 3, 5, 1, 7, 19};
            int[] h11 = {19, 5, 10, 4, 1, 3, 7};
            int[] h12 = {1, 3, 4, 10, 5, 7, 19};
            CollectionAssert.AreEqual(h11, _bh.MaxHeapify(a1));
            CollectionAssert.AreEqual(h12, _bh.MinHeapify(a1));

            int[] a2 = {12, 11, 13, 5, 6, 7};
            int[] h21 = {13, 11, 12, 5, 6, 7};
            int[] h22 = {5, 6, 7, 12, 11, 13};
            CollectionAssert.AreEqual(h21, _bh.MaxHeapify(a2));
            CollectionAssert.AreEqual(h22, _bh.MinHeapify(a2));

        }

        [TestMethod]
        public void HeapifyWithEqualElements()
        {
            int[] a1 = { 4, 10, 7, 5, 7, 7, 19 };
            int[] h11 = { 19, 7, 10, 4, 5, 7, 7 };
            int[] h12 = {4, 5, 7, 10, 7, 7, 19};
            CollectionAssert.AreEqual(h11, _bh.MaxHeapify(a1));
            CollectionAssert.AreEqual(h12, _bh.MinHeapify(a1));


            int[] a2 = {2, 2, 1, 1, 5, 6, 7, 1};
            int[] h21 = {7, 2, 6, 1, 2, 1, 5, 1};
            int[] h22 = {1, 1, 2, 1, 5, 6, 7, 2};
            CollectionAssert.AreEqual(h21, _bh.MaxHeapify(a2));
            CollectionAssert.AreEqual(h22, _bh.MinHeapify(a2));
        }

        [TestMethod]
        public void HeapSortWithoutEqualElements()
        {
            int[] a1 = { 4, 10, 3, 5, 1, 7, 19 };
            int[] s1 = {1, 3, 4, 5, 7, 10, 19};
            CollectionAssert.AreEqual(s1, _bh.HeapSort(a1));

            int[] a2 = { 12, 11, 13, 5, 6, 7 };
            int[] s2 = {5, 6, 7, 11, 12, 13};
            CollectionAssert.AreEqual(s2, _bh.HeapSort(a2));
        }


        [TestMethod]
        public void HeapSortWithEqualElements()
        {
            int[] a1 = { 4, 10, 7, 5, 7, 7, 19 };
            int[] s1 = {4, 5, 7, 7, 7, 10, 19};
            CollectionAssert.AreEqual(s1, _bh.HeapSort(a1));

            int[] a2 = { 2, 2, 1, 1, 5, 6, 7, 1 };
            int[] s2 = {1, 1, 1, 2, 2, 5, 6, 7};
            CollectionAssert.AreEqual(s2, _bh.HeapSort(a2));

        }
    }
}
