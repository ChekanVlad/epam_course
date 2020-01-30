using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Specialization class
    /// </summary>
    [Table(Name = "Specializations")]
    public class Specialization : ITable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Title")]
        public string Title { get; set; }

        public Specialization() { }

        public Specialization(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public Specialization(string title)
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
            Specialization specialization = obj as Specialization;
            if (specialization == null)
            {
                return false;
            }

            return Title == specialization.Title;
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
