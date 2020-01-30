using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Subject class
    /// </summary>
    [Table(Name = "Subjects")]
    public class Subject : ITable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Title")]
        public string Title { get; set; }

        public Subject() { }

        public Subject(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Subject(string title)
        {
            Title = title;
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
            Subject subject = obj as Subject;
            if (subject == null)
            {
                return false;
            }

            return Title == subject.Title;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 22 * Title.Length;
        }
    }
}
