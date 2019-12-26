using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BinaryTree
{
    /// <summary>
    /// Tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Tree<T> where T : IComparable<T>
    {
        Tree<T> parent, left, right;
        public T value;
        private List<T> listForPrint = new List<T>();

        public Tree()
        {
        }

        /// <summary>
        /// Tree constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        public Tree(T value, Tree<T> parent)
        {
            this.value = value;
            this.parent = parent;
        }

        /// <summary>
        /// Serialize tree
        /// </summary>
        public void SerializateTree()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Tree<T>));

            using (FileStream fs = new FileStream("E:\\SD-23\\3k\\labs_oop_repos_xota6\\epam_course\\Task5\\BinaryTree\\mySerTree.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }
        /// <summary>
        /// Add value to Tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (value.CompareTo(this.value) < 0)
            {
                if (this.left == null)
                {
                    this.left = new Tree<T>(value, this);
                }
                else if (this.left != null)
                    this.left.Add(value);
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new Tree<T>(value, this);
                }
                else if (this.right != null)
                    this.right.Add(value);
            }
        }

        private Tree<T> Search(Tree<T> tree, T value)
        {
            if (tree == null) return null;
            switch (value.CompareTo(tree.value))
            {
                case 1: return Search(tree.right, value);
                case -1: return Search(tree.left, value);
                case 0: return tree;
                default: return null;
            }
        }

        /// <summary>
        /// Find element in tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Tree<T> Search(T value)
        {
            return Search(this, value);
        }

        /// <summary>
        /// Remove element in tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            //Проверяем, существует ли данный узел
            Tree<T> tree = Search(value);
            if (tree == null)
            {
                //Если узла не существует, вернем false
                return false;
            }
            Tree<T> curTree;

            //Если удаляем корень
            if (tree == this)
            {
                if (tree.right != null)
                {
                    curTree = tree.right;
                }
                else curTree = tree.left;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }
                T temp = curTree.value;
                this.Remove(temp);
                tree.value = temp;

                return true;
            }

            //Удаление листьев
            if (tree.left == null && tree.right == null && tree.parent != null)
            {
                if (tree == tree.parent.left)
                    tree.parent.left = null;
                else
                {
                    tree.parent.right = null;
                }
                return true;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (tree.left != null && tree.right == null)
            {
                //Меняем родителя
                tree.left.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.left;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.left;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.left == null && tree.right != null)
            {
                //Меняем родителя
                tree.right.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.right;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.right;
                }
                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (tree.right != null && tree.left != null)
            {
                curTree = tree.right;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }

                //Если самый левый элемент является первым потомком
                if (curTree.parent == tree)
                {
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curTree.right != null)
                    {
                        curTree.right.parent = curTree.parent;
                    }
                    curTree.parent.left = curTree.right;
                    curTree.right = tree.right;
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    tree.right.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }

                    return true;
                }
            }
            return false;
        }
        /*
        private void Print(Tree<T> node)
        {
            if (node == null) return;
            Print(node.left);
            listForPrint.Add(node.value);
            Console.Write(node + " ");
            if (node.right != null)
                Print(node.right);
        }
        
        /// <summary>
        /// Print all elements
        /// </summary>
        public void Print()
        {
            listForPrint.Clear();
            Print(this);
            Console.WriteLine();
        }
        */
        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }
}