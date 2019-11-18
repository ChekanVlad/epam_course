using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VPLib;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            Vector v1 = new Vector(12.5, -22.3, 89);
            Vector v2 = new Vector(6.7, 0, 16.1);
            Vector sum = new Vector(19.2, -22.3, 105.1);
            Vector sub = new Vector(5.8, -22.3, 72.9);
            Vector multVec = new Vector(-359.03, 395.05, 149.41);
            double multScalar = 1516.65;
            Assert.IsTrue(v1 + v2 == sum);
            Assert.IsTrue(v1 - v2 == sub);
            Assert.IsTrue(v1 / v2 == multVec);
            Assert.AreEqual(v1 * v2, multScalar);
        }
    }
}
