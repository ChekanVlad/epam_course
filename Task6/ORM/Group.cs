using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Group(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Group(string title)
        {
            Title = title;
        }
    }
}
