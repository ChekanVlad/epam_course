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
    }
}
