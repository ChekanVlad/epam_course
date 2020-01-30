using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Examenator class
    /// </summary>
    [Table(Name = "Examinators")]
    public class Examinator : ITable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Fio")]
        public string Fio { get; set; }

        public Examinator() { }

        public Examinator(int id, string fio)
        {
            Id = id;
            Fio = fio;
        }

        public Examinator(string fio)
        {
            Fio = fio;
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
            Examinator examinator = obj as Examinator;
            if (examinator == null)
            {
                return false;
            }

            return Fio == examinator.Fio;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 22 * Fio.Length;
        }
    }
}
