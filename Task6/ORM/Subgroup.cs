using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Subgroup class
    /// </summary>
    public class Subgroup
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Subgroup(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Subgroup(string title)
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
            Subgroup subgroup = obj as Subgroup;
            if (subgroup == null)
            {
                return false;
            }

            return Title == subgroup.Title;
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
