using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAOClasses
{
    /// <summary>
    /// DAO layer (Subject)
    /// </summary>
    public class DAOSubject : DAO<Subject>
    {
        public DAOSubject(string connectionString) : base(connectionString)
        {
        }
    }
}
