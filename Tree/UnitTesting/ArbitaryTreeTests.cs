using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree;

namespace UnitTesting
{
    [TestClass]
    public class ArbitaryTreeTests
    {
        private ArbitaryTree<int> root;

        [TestInitialize]
        public void Initializer()
        {
            ArbitaryTree<int> node = new ArbitaryTree<int>(1)
                                     {
                                         Children = new List<ArbitaryTree<int>>(new[]
                                                                                {
                                                                                    new ArbitaryTree<int>(2),
                                                                                    new ArbitaryTree<int>(2),
                                                                                    new ArbitaryTree<int>(2)
                                                                                })
                                                    {
                                                        [1] =
                                                        {
                                                            Children = new List<ArbitaryTree<int>>(new[]
                                                                                                   {
                                                                                                       new ArbitaryTree
                                                                                                           <int>(3),
                                                                                                       new ArbitaryTree
                                                                                                           <int>(3)
                                                                                                   })
                                                        },
                                                        [0] =
                                                        {
                                                            Children =
                                                                new List<ArbitaryTree<int>>(new[]
                                                                                            {
                                                                                                new ArbitaryTree<int>(4)
                                                                                            })
                                                                {
                                                                    [0] =
                                                                    {
                                                                        Children = new List<ArbitaryTree<int>>()
                                                                                   {
                                                                                       new ArbitaryTree<int>(5),
                                                                                       new ArbitaryTree<int>(5),
                                                                                       new ArbitaryTree<int>(5)
                                                                                   }
                                                                    }
                                                                }
                                                        }
                                                    }
                                     };





            root = node;
        }

        [TestMethod]
        public void FindTreeHeightTest()
        {

            int height = ArbitaryTree<int>.FindTreeHeight(root);
            Assert.AreEqual(4, height);

        }
    }
}
