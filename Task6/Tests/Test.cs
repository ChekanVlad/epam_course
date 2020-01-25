using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MySql.Data.MySqlClient;
using DAOClasses;
using ORM;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        private static string connectionString = "server=localhost;user=root;database=task6;password=G8129307csgo;";
        private DAOFactory factory = DAOFactory.GetInstance(connectionString);
        [Test]
        public void TestMethod()
        {
            Assert.IsTrue(true);
        }
    }
}
