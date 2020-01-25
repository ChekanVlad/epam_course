using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public double Mark { get; set; }
        public Result(int id, int studentId, int examId, double mark)
        {
            Id = id;
            StudentId = studentId;
            ExamId = examId;
            Mark = mark;
        }

        public Result(int studentId, int examId, double mark)
        {
            StudentId = studentId;
            ExamId = examId;
            Mark = mark;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Result result = obj as Result;
            if (result == null)
            {
                return false;
            }

            return StudentId == result.StudentId && ExamId == result.ExamId && Mark == result.Mark;
        }

        public override int GetHashCode()
        {
            return 2 * StudentId + 222 * ExamId + 17 * (int)Mark;
        }
    }
}
