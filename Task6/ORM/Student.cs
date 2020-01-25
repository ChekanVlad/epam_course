using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Student
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public int GroupId { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public Student(int id, string fio, int groupId, string gender, DateTime birthDate)
        {
            Id = id;
            Fio = fio;
            GroupId = groupId;
            Gender = gender;
            BirthDate = birthDate;
        }

        public Student(string fio, int groupId, string gender, DateTime birthDate)
        {
            Fio = fio;
            GroupId = groupId;
            Gender = gender;
            BirthDate = birthDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }

            return Fio == student.Fio && GroupId == student.GroupId && Gender == student.Gender && BirthDate == student.BirthDate;
        }

        public override int GetHashCode()
        {
            return 2 * Fio.Length + 222 * GroupId + 17 * Gender.Length + 6 * BirthDate.Year;
        }
    }
}
