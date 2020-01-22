using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql;
using DAO;
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Factory factory = DAOFactory.getInstance("");
        }
    }
}
