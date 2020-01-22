using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAO
{
    public abstract class Factory
    {
        public abstract IDAO<Student> GetDaoStudent();
        public abstract IDAO<Group> GetDaoGroup();
        public abstract IDAO<Timetable> GetDaoExam();
        public abstract IDAO<Result> GetDaoResult();
        public abstract IDAO<Subject> GetDaoSubject();
    }

    public class DAOFactory : Factory
    {
        private static DAOFactory instance;
        public static string ConnectionString { get; private set; }
        private DAOFactory()
        { }
        public static DAOFactory getInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new DAOFactory();
                ConnectionString = connectionString;
            }
            return instance;
        }
        public override IDAO<Student> GetDaoStudent()
        {
            DAOStudent daoStudent = new DAOStudent(ConnectionString);
            return daoStudent;
        }

        public override IDAO<Group> GetDaoGroup()
        {
            DAOGroup daoGroup = new DAOGroup(ConnectionString);
            return daoGroup;
        }

        public override IDAO<Result> GetDaoResult()
        {
            DAOResult daoResult = new DAOResult(ConnectionString);
            return daoResult;
        }

        public override IDAO<Timetable> GetDaoExam()
        {
            DAOTimetable daoExam = new DAOTimetable(ConnectionString);
            return daoExam;
        }

        public override IDAO<Subject> GetDaoSubject()
        {
            DAOSubject daoSubject = new DAOSubject(ConnectionString);
            return daoSubject;
        }
    }
}
