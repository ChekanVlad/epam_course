using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        string filePath1 = "..\\..\\..\\xml_serialized\\mySerTree.xml";
        string filePath2 = "..\\..\\..\\xml_serialized\\mySerTree2.xml";
        string filePath3 = "..\\..\\..\\xml_serialized\\mySerTree3.xml";
        /// <summary>
        /// If deserialize is impossible
        /// </summary>
        [TestMethod]
        public void ExceptionTest()
        {
            void func()
            {
                Tree<int> tree = new Tree<int>(new Student<int>("Name", "TestName", DateTime.Now, 8), null);
                tree.DeserializeTree(filePath1);
            }
            Assert.ThrowsException<Exception>(func);
            //Assert.IsTrue(tree.Search(17) == null);
        }

        /// <summary>
        /// Serialize and Deserialize tree
        /// </summary>
        [TestMethod]
        public void XmlTest()
        {
            Tree<int> tree1 = new Tree<int>();
            tree1.Add(new Student<int>("Valentin", "Math", DateTime.Now, 6));
            tree1.Add(new Student<int>("Vlad", "Russian", DateTime.Now, 1));
            tree1.Add(new Student<int>("Sergei", "English", DateTime.Now, 4));
            tree1.Add(new Student<int>("Eugene", "Literature", DateTime.Now, 10));
            tree1.Add(new Student<int>("Capone", "Biology", DateTime.Now, 9));
            tree1.SerializeTree(filePath2);
            Tree<int> tree2 = new Tree<int>();
            tree2.DeserializeTree(filePath2);
            tree1.PreOrderTraversal();
            tree2.PreOrderTraversal();
            List<Student<int>> list1 = tree1.elements;
            List<Student<int>> list2 = tree2.elements;
            Assert.AreEqual(list1[0].ToString(), list2[0].ToString());
        }

        /// <summary>
        /// test for add el to tree
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            Tree<double> tree1 = new Tree<double>();
            tree1.Add(new Student<double>("Valentin", "Math", DateTime.Now, 6.1));
            tree1.Add(new Student<double>("Vlad", "Russian", DateTime.Now, 1.6));
            tree1.Add(new Student<double>("Sergei", "English", DateTime.Now, 4.5));
            tree1.Add(new Student<double>("Eugene", "Literature", DateTime.Now, 9.9));
            tree1.Add(new Student<double>("Capone", "Biology", DateTime.Now, 8.3));
            tree1.PreOrderTraversal();
            foreach(Student<double> i in tree1.elements)
            {
                Assert.IsTrue(tree1.Search(i.Mark) != null);
            }
        }

        /// <summary>
        /// test for remove 
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            Tree<double> tree = new Tree<double>();
            tree.DeserializeTree(filePath3);
            tree.Remove(6.1);
            Assert.IsTrue(tree.Search(6.1) == null);
        }

        /// <summary>
        /// test for search 
        /// </summary>
        [TestMethod]
        public void SearchTest()
        {
            Tree<double> tree = new Tree<double>();
            tree.DeserializeTree(filePath3);
            Assert.IsTrue(tree.Search(22.11) == null);
            Assert.IsTrue(tree.Search(1.6) != null && tree.Search(1.6).value == 1.6);
        }

        /// <summary>
        /// Balance test
        /// </summary>
        [TestMethod]
        public void BalanceTest()
        {
            Tree<int> tree1 = new Tree<int>();
            tree1.Add(new Student<int>("Valentin", "Math", DateTime.Now, 1));
            tree1.Add(new Student<int>("Vlad", "Russian", DateTime.Now, 2));
            tree1.Add(new Student<int>("Sergei", "English", DateTime.Now, 3));
            tree1.Add(new Student<int>("Eugene", "Literature", DateTime.Now, 4));
            tree1.Add(new Student<int>("Capone", "Biology", DateTime.Now, 5));
            tree1.Add(new Student<int>("Stan", "Chemistry", DateTime.Now, 6));
            tree1.Add(new Student<int>("Lee", "Japanese", DateTime.Now, 7));
            tree1.BalanceTree();
            //
            Assert.AreEqual(tree1.value, 4);
            Assert.AreEqual(tree1.left.value, 2);
            Assert.AreEqual(tree1.left.right.value, 3);
            Assert.AreEqual(tree1.right.left.value, 5);
            Assert.AreEqual(tree1.right.value, 6);
        }
    }
}
