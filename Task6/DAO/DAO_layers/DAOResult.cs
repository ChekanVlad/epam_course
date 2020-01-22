using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAO
{
    class DAOResult : DAO<Result>
    {
        public DAOResult(string connectionString) : base(connectionString)
        {

        }
    }
}
