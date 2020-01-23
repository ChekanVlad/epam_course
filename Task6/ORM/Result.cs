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
        public int TimetableId { get; set; }
        public double Mark { get; set; }
        public Result(int id, int studentId, int timetableId, double mark)
        {
            Id = id;
            StudentId = studentId;
            TimetableId = timetableId;
            Mark = mark;
        }

        public Result(int studentId, int timetableId, double mark)
        {
            StudentId = studentId;
            TimetableId = timetableId;
            Mark = mark;
        }
    }
}
