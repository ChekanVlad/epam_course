using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Exam
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectType { get; set; }
        public Exam(int id, DateTime date, int groupId, int subjectId, string subjectType)
        {
            Id = id;
            Date = date;
            GroupId = groupId;
            SubjectId = subjectId;
            SubjectType = subjectType;
        }
        public Exam(DateTime date, int groupId, int subjectId, string subjectType)
        {
            Date = date;
            GroupId = groupId;
            SubjectId = subjectId;
            SubjectType = subjectType;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Exam exam = obj as Exam;
            if (exam == null)
            {
                return false;
            }

            return Date == exam.Date && GroupId == exam.GroupId && SubjectId == exam.SubjectId && SubjectType == exam.SubjectType;
        }

        public override int GetHashCode()
        {
            return 2 * Date.Year + 222 * GroupId + 17 * SubjectId;
        }

    }
}

