﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAO
{
    class DAOStudent : DAO<Student>
    {
        public DAOStudent(string connectionString) : base(connectionString)
        {

        }
    }
}
