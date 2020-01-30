using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Student class
    /// </summary>
    public class Student
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Fio")]
        public string Fio { get; set; }

        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        [Column(Name = "Gender")]
        public string Gender { get; set; }

        [Column(Name = "BirthDate")]
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
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }

            return Fio == student.Fio && GroupId == student.GroupId && Gender == student.Gender && BirthDate == student.BirthDate;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 2 * Fio.Length + 222 * GroupId + 17 * Gender.Length + 6 * BirthDate.Year;
        }
    }
}
