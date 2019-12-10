using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOD;

namespace NOD_UnitTest
{
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// Unit Test (Euclidean and Stein methods)
        /// </summary>
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

        /// <summary>
        /// Unit Test (Euclidean for 3 el)
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            int a = 81, b = 27, c = 63;
            double time = 0;
            int nodE = NODMethods.Euclidean(a, b, c, ref time);
            int nod = 9;
            Assert.AreEqual(nod, nodE);
        }

        /// <summary>
        /// Unit Test (Euclidean for 4 el)
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            int a = 152, b = 57, c = 76, d = 95;
            double time = 0;
            int nodE = NODMethods.Euclidean(a, b, c, d, ref time);
            int nod = 19;
            Assert.AreEqual(nod, nodE);
        }

        /// <summary>
        /// Unit Test (Euclidean for 5 el)
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            int a = 152, b = 57, c = 76, d = 95, e = 133;
            double time = 0;
            int nodE = NODMethods.Euclidean(a, b, c, d, e, ref time);
            int nod = 19;
            Assert.AreEqual(nod, nodE);
        }
    }
}
