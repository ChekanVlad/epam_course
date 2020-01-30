using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Result class
    /// </summary>
    public class Result
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        [Column(Name = "ExamId")]
        public int ExamId { get; set; }

        [Column(Name = "Mark")]
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
        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 2 * StudentId + 222 * ExamId + 17 * (int)Mark;
        }
    }
}
