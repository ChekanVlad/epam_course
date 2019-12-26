using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Student
    {
        string Name { get; set; }
        string TestName { get; set; }
        DateTime TestDate { get; set; }
        int Mark { get; set; }

        public Student(string name, string testName, DateTime testDate, int mark)
        {
            Name = name;
            TestName = testName;
            TestDate = testDate;
            Mark = mark;    
        }
    }
}
