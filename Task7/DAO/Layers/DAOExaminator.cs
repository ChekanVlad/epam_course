using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAOClasses
{
    /// <summary>
    /// DAO layer (Result)
    /// </summary>
    public class DAOExaminator : DAO<Examinator>
    {
        public DAOExaminator(string connectionString) : base(connectionString)
        {
        }
    }
}
