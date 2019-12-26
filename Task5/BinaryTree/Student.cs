using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    [Serializable]
    public class Student<T>
    {
        public string Name { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public T Mark { get; set; }

        public Student() { }

        public Student(string name, string testName, DateTime testDate, T mark)
        {
            Name = name;
            TestName = testName;
            TestDate = testDate;
            Mark = mark;
        }

        public override string ToString()
        {
            return Name + " " + TestName + " " + TestDate.ToShortDateString() + " " + Mark;
        }
    }
}
