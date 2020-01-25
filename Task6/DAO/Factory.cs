using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOClasses
{
    public abstract class Factory
    {
        public abstract DAOSubgroup GetDAOSubgroup();
        public abstract DAOSubject GetDAOSubject();
        public abstract DAOStudent GetDAOStudent();
        public abstract DAOExam GetDAOExam();
        public abstract DAOResult GetDAOResult();
    }

    public class DAOFactory : Factory
    {
        private static DAOFactory instance;
        private static DAOSubgroup DAOsubgroup;
        private static DAOSubject DAOsubject;
        private static DAOStudent DAOstudent;
        private static DAOExam DAOexam;
        private static DAOResult DAOresult;
        private static string connectionString;
        private DAOFactory()
        {

        }

        public static DAOFactory GetInstance(string connString)
        {
            if(instance == null)
            {
                instance = new DAOFactory();
                connectionString = connString;
            }
            return instance;
        }

        public override DAOExam GetDAOExam()
        {
            if(DAOexam == null)
            {
                DAOexam = new DAOExam(connectionString);
            }
            return DAOexam;
        }

        public override DAOSubgroup GetDAOSubgroup()
        {
            if (DAOsubgroup == null)
            {
                DAOsubgroup = new DAOSubgroup(connectionString);
            }
            return DAOsubgroup;
        }

        public override DAOResult GetDAOResult()
        {
            if (DAOresult == null)
            {
                DAOresult = new DAOResult(connectionString);
            }
            return DAOresult;
        }

        public override DAOStudent GetDAOStudent()
        {
            if (DAOstudent == null)
            {
                DAOstudent = new DAOStudent(connectionString);
            }
            return DAOstudent;
        }

        public override DAOSubject GetDAOSubject()
        {
            if (DAOsubject == null)
            {
                DAOsubject = new DAOSubject(connectionString);
            }
            return DAOsubject;
        }
    }
}
