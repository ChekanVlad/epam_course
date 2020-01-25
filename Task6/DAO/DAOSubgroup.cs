using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAOClasses
{
    /// <summary>
    /// DAO layer (Subgroup)
    /// </summary>
    public class DAOSubgroup : DAO<Subgroup>
    {
        public DAOSubgroup(string connectionString) : base(connectionString)
        {
        }
    }
}
