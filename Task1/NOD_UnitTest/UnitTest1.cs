using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOD;

namespace NOD_UnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 152, b = 57;
            double time = 0;
            int nodE = NODMethods.Euclidean(a, b, ref time);     
            int nodS = NODMethods.Stein(a, b, ref time);
            int nod = 19;
            Assert.AreEqual(nod, nodE, nodS);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int a = 152, b = 57, c = 76;
            int nodE = NODMethods.Euclidean(a, b, c);
            int nod = 19;
            Assert.AreEqual(nod, nodE);
        }
    }
}
