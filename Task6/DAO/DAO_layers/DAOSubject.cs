﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAO
{
    class DAOSubject : DAO<Subject>
    {
        public DAOSubject(string connectionString) : base(connectionString)
        {

        }
    }
}
