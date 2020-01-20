using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Subject(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Subject(string title)
        {
            Title = title;
        }
    }
}
