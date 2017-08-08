using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application
{
    [TestClass]
    public class ConnectivityTests
    {
        private Connectivity _connectivity;

        [TestInitialize]
        public void Initialize()
        {
            _connectivity = new Connectivity();
        }

        [TestMethod]
        public void TestIslandCount()
        {
            int[,] input =
            {
                {1, 1, 0, 0, 0},
                {0, 1, 0, 0, 1},
                {1, 0, 0, 1, 1},
                {0, 0, 0, 0, 0},
                {1, 0, 1, 0, 1}
            };
            
            Assert.AreEqual(5, _connectivity.CountIslands(input));
        }

        [TestMethod]
        public void TestDijkstra()
        {
            int[,] graph1 =
            {
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };

            int[] distances = {0, 4, 12, 19, 21, 11, 9, 8, 14};
            CollectionAssert.AreEqual(distances, _connectivity.Dijkstra(graph1, 0));
        }
    }
}
