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
        public void VectorOperations()
        {
            Vector v1 = new Vector(12.5, -22.3, 89);
            Vector v2 = new Vector(6.7, 0, 16.1);
            Vector sum = new Vector(19.2, -22.3, 105.1);
            Vector sub = new Vector(5.8, -22.3, 72.9);
            Vector multVec = new Vector(-359.03, 395.05, 149.41);
            double multScalar = 1516.65;
            Assert.IsTrue((v1 + v2) == sum);
            Assert.IsTrue((v1 - v2) == sub);
            Assert.IsTrue((v1 ^ v2) == multVec);
            Assert.AreEqual(v1 * v2, multScalar);
        }

        [TestMethod]
        public void PolynomOperations()
        {
            Polynom p1 = new Polynom(new double[] { 15.2, 13.3, -6, 0 });
            Polynom p2 = new Polynom(new double[] { -7.3, 0.9, 12, 6, 3 });
            Polynom sum = new Polynom(new double[] { -7.3, 16.1, 0, 0, 25.3, 3 });
            Polynom sub = new Polynom(new double[] { 7.3, 14.3, 1.3, -12, -3 });
            Polynom mult = new Polynom(new double[] { 0, -18, 3.9, 53.4, -245.4, 238.17, -8.341, -110,96});
            Assert.IsTrue((p1 + p2) == sum);
            Assert.IsTrue((p1 - p2) == sub);
            Assert.IsTrue((p1 * p2) == mult);

        }
    }
}
