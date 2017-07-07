using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interface
{
    [TestClass]
    public class ExplicitImplementationTests
    {
        private IPerson p1;
        private IPerson<string> p2;
        private Person p3;

        [TestInitialize]
        public void Init()
        {
            p1 = new Person();
            // visible methods: Test1(), Test2(), Add(), Update(), NgenericAdd()

            p2 = new Person();
            // visible methods: Test1(), Test3(), Add(), Update(), GenericAdd()

            p3 = new Person();
            // visible methods: Test1(), Add(), Update()
        }
      

        [TestMethod]
        public void ExplicitHiddenMethodCallsImplicitHidingMethod()
        {
            // 1. if the explcit method on IPerson is hidden
            // 2. if the IPerson type can access to the hidding method on IPerson<T>
            Assert.AreEqual(10, p1.Test1());

            var e = p1.Add().GetEnumerator(); // IEnumerator doesn't implement IDisposable
            if(e.MoveNext())
                Assert.AreEqual("Alan", e.Current.ToString());
        }


        [TestMethod]
        public void CallImplicitMethodFromInterfaceInstance()
        {
            Assert.AreEqual(11, p2.Test1());

            using (var e = p2.Update())
            {
                if(e.MoveNext())
                    Assert.AreEqual("John", e.Current);
                if(e.MoveNext())
                    Assert.AreEqual("H", e.Current);
            }
        }

        [TestMethod]
        public void CallImplicitMethodFromClassInstance()
        {
            Assert.AreEqual(11, p3.Test1());
        }

        [TestMethod]
        public void CallExplicitMethodFromInterfaceInstance()
        {
            Assert.AreEqual(20, p1.Test2());

            var e = p1.NgeneicAdd();
            if(e.MoveNext())
                Assert.AreEqual("KY", e.Current);
            
        }

        [TestMethod]
        public void ExplicitMethodCallsImplicitMethodWithoutHiding()
        {
            Assert.AreEqual(31, p2.Test3());
            using (var e = p2.GenericAdd().GetEnumerator())
            {
                if(e.MoveNext()) // MoveNext must be called before retrieving the first item
                    Assert.AreEqual("Alan", e.Current);
            }
        }
    }
}
