using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAO
{
    class DAOGroup : DAO<Group>
    {
        public DAOGroup(string connectionString) : base(connectionString)
        {

        }
    }
}