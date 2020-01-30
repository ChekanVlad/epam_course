using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOClasses
{
    /// <summary>
    /// Factory
    /// </summary>
    public abstract class Factory
    {
        public abstract DAOSubgroup GetDAOSubgroup();
        public abstract DAOSubject GetDAOSubject();
        public abstract DAOStudent GetDAOStudent();
        public abstract DAOExam GetDAOExam();
        public abstract DAOResult GetDAOResult();
        public abstract DAOExaminator GetDAOExaminator();
        public abstract DAOSpecialization GetDAOSpecialization();
    }

    /// <summary>
    /// Factory realisation
    /// </summary>
    public class DAOFactory : Factory
    {
        private static DAOFactory instance;
        private static DAOSubgroup DAOsubgroup;
        private static DAOSubject DAOsubject;
        private static DAOStudent DAOstudent;
        private static DAOExam DAOexam;
        private static DAOResult DAOresult;
        private static DAOExaminator DAOexaminator;
        private static DAOSpecialization DAOspecialization;
        private static string connectionString;
        private DAOFactory()
        {

        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static DAOFactory GetInstance(string connString)
        {
            if (instance == null)
            {
                instance = new DAOFactory();
                connectionString = connString;
            }
            return instance;
        }

        /// <summary>
        /// Creating DAO layer (exam)
        /// </summary>
        /// <returns></returns>
        public override DAOExam GetDAOExam()
        {
            if (DAOexam == null)
            {
                DAOexam = new DAOExam(connectionString);
            }
            return DAOexam;
        }

        /// <summary>
        /// Creating DAO layer (Subgroup)
        /// </summary>
        /// <returns></returns>
        public override DAOSubgroup GetDAOSubgroup()
        {
            if (DAOsubgroup == null)
            {
                DAOsubgroup = new DAOSubgroup(connectionString);
            }
            return DAOsubgroup;
        }

        /// <summary>
        /// Creating DAO layer (Result)
        /// </summary>
        /// <returns></returns>
        public override DAOResult GetDAOResult()
        {
            if (DAOresult == null)
            {
                DAOresult = new DAOResult(connectionString);
            }
            return DAOresult;
        }

        /// <summary>
        /// Creating DAO layer (Student)
        /// </summary>
        /// <returns></returns>
        public override DAOStudent GetDAOStudent()
        {
            if (DAOstudent == null)
            {
                DAOstudent = new DAOStudent(connectionString);
            }
            return DAOstudent;
        }

        /// <summary>
        /// Creating DAO layer (Subject)
        /// </summary>
        /// <returns></returns>
        public override DAOSubject GetDAOSubject()
        {
            if (DAOsubject == null)
            {
                DAOsubject = new DAOSubject(connectionString);
            }
            return DAOsubject;
        }

        /// <summary>
        /// Creating DAO layer (Examinator)
        /// </summary>
        /// <returns></returns>
        public override DAOExaminator GetDAOExaminator()
        {
            if (DAOexaminator == null)
            {
                DAOexaminator = new DAOExaminator(connectionString);
            }
            return DAOexaminator;
        }

        /// <summary>
        /// Creating DAO layer (Specialization)
        /// </summary>
        /// <returns></returns>
        public override DAOSpecialization GetDAOSpecialization()
        {
            if (DAOspecialization == null)
            {
                DAOspecialization = new DAOSpecialization(connectionString);
            }
            return DAOspecialization;
        }
    }
}
