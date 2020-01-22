using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAO
{
    class DAOTimetable : DAO<Timetable>
    {
        public DAOTimetable(string connectionString) : base(connectionString)
        {

        }
    }
}