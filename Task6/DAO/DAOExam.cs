using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAOClasses
{
    public class DAOExam : DAO<Exam>
    {
        public DAOExam(string connectionString) : base(connectionString)
        {
        }
    }
}
