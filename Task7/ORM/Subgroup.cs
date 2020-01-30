using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
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
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Title")]
        public string Title { get; set; }

        [Column(Name = "SpecializationId")]
        public int SpecializationId { get; set; }

        public Subgroup(int id, string title, int specializationId)
        {
            Id = id;
            Title = title;
            SpecializationId = specializationId;
        }
        public Subgroup(string title, int specializationId)
        {
            Title = title;
            SpecializationId = specializationId;
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

            return Title == subgroup.Title && SpecializationId == subgroup.SpecializationId;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 22 * Title.Length + 17 * SpecializationId;
        }
    }
}
