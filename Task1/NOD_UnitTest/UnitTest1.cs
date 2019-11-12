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
            int nodactual = NODMethods.Euclidean(a, b);
            int nod = 19;
            Assert.AreEqual(nod, nodactual);
        }
    }
}
