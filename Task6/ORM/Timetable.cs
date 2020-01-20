using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Timetable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectType { get; set; }
        public Timetable(int id, DateTime date, int groupId, int subjectId, string subjectType)
        {
            Id = id;
            Date = date;
            GroupId = groupId;
            SubjectId = subjectId;
            SubjectType = subjectType;
        }
        public Timetable(DateTime date, int groupId, int subjectId, string subjectType)
        {
            Date = date;
            GroupId = groupId;
            SubjectId = subjectId;
            SubjectType = subjectType;
        }
    }
}
