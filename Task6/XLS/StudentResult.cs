using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLS
{
    /// <summary>
    /// SrudentResult class
    /// </summary>
    public class StudentResult
    {
        public string Fio { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        //public string GroupTitle { get; set; }
        public string SubjectTitle { get; set; }
        public string ExamType { get; set; }
        public double Mark { get; set; }
        public DateTime Date { get; set; }
    }
}
