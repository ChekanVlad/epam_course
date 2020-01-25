using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
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

        public override int GetHashCode()
        {
            return 22 * Title.Length;
        }
    }
}
