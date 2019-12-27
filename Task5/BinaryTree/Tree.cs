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
        private XmlSerializer formatter = new XmlSerializer(typeof(Tree<T>));
        [XmlIgnore]
        public Tree<T> parent, left, right;
        [XmlIgnore]
        public T value;
        [XmlIgnore]
        Student<T> studentInfo;
        public List<Student<T>> elements = new List<Student<T>>();

        /// <summary>
        /// 
        /// </summary>
        public Tree()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <param name="parent"></param>
        public Tree(Student<T> studentInfo, Tree<T> parent)
        {
            this.studentInfo = studentInfo;
            value = studentInfo.Mark;
            this.parent = parent;
        }

        /// <summary>
        /// Serialize tree
        /// </summary>
        public void SerializeTree(string filePath)
        {
            PreOrderTraversal();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        /// <summary>
        /// Deserialize tree
        /// </summary>
        public void DeserializeTree(string filePath)
        {
            if(studentInfo != null)
            {
                throw new Exception("You must deserialize info into empty tree.");
            }
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                Tree<T> newTree = (Tree<T>)formatter.Deserialize(fs);
                this.elements = newTree.elements;
                foreach(Student<T> i in elements)
                {
                    this.Add(i);
                }
            }
        }

        //
        /// <summary>
        /// Add value to Tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(Student<T> studentInfo)
        {
            if(this.studentInfo == null)
            {
                this.studentInfo = studentInfo;
                value = studentInfo.Mark;
                return;
            }

            if (studentInfo.Mark.CompareTo(value) < 0)
            {
                if (left == null)
                {
                    left = new Tree<T>(studentInfo, this);
                }
                else if (left != null)
                    left.Add(studentInfo);
            }
            else
            {
                if (right == null)
                {
                    right = new Tree<T>(studentInfo, this);
                }
                else if (right != null)
                    right.Add(studentInfo);
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
            Tree<T> tree = Search(value);
            if (tree == null)
            {
                return false;
            }
            Tree<T> curTree;

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

            if (tree.right != null && tree.left != null)
            {
                curTree = tree.right;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }

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

        /// <summary>
        /// PreOrder (префиксный обход, сохраняет структуру)
        /// </summary>
        public void PreOrderTraversal()
        {
            elements.Clear();
            PreOrderTraversal(this);
            //return elements;
        }

        private void PreOrderTraversal(Tree<T> node)
        {
            if (node != null)
            {
                //action
                elements.Add(node.studentInfo);
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }
        }
    }
}