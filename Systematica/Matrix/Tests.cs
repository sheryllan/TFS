using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestHasRowOrColumn()
        {
            int[,] case1 = {{1, 1, 1}, {0, 0, 0}, {1, 0, 1}}; // has a row of zeros
            int[,] case2 = {{1, 1, 0}, {0, 1, 0}, {1, 1, 0}}; // has a column of zeros
            int[,] case3 = {{1, 0, 1, 0}, {0, 1, 0, 1}, {1, 0, 1, 0}, {0, 1, 0, 1}}; // has no row/column of zeros

            MatrixHelper matrix = new MatrixHelper();
            Assert.IsTrue(matrix.hasRowOrColumnOfZeros(case1));
            Assert.IsTrue(matrix.hasRowOrColumnOfZeros(case2));
            Assert.IsFalse(matrix.hasRowOrColumnOfZeros(case3));
        }


        [TestMethod]
        public void TestHasDiagonal()
        {
            int[,] case1 = {{0, 1, 1}, {1, 1, 1}, {1, 1, 1}};
            int[,] case2 = {{1, 0, 1}, {0, 0, 1}, {1, 1, 0}};
            int[,] case3 = {{0, 1, 1}, {1, 0, 1}, {1, 1, 0}};
            int[,] case4 = {{1, 1, 0}, {1, 1, 0}, {0, 1, 0}};
            int[,] case5 = {{1, 0, 1, 1}, {1, 1, 0, 1}, {0, 1, 0, 1}, {1, 1, 0, 1}};

            MatrixHelper matrix = new MatrixHelper();
            Assert.IsTrue(matrix.hasDiagonalOfZeros(case1));
            Assert.IsTrue(matrix.hasDiagonalOfZeros(case2));
            Assert.IsTrue(matrix.hasDiagonalOfZeros(case3));
            Assert.IsTrue(matrix.hasDiagonalOfZeros(case4));
            Assert.IsFalse(matrix.hasDiagonalOfZeros(case5));

        }
    }
}
