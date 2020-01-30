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
    public class Examenator
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Fio")]
        public string Fio { get; set; }

        public Examenator(int id, string fio)
        {
            Id = id;
            Fio = fio;
        }

        public Examenator(string fio)
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
            Examenator examenator = obj as Examenator;
            if (examenator == null)
            {
                return false;
            }

            return Fio == examenator.Fio;
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
