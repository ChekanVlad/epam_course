using System.Collections.Generic;
using System.Linq;
using DAOClasses;
using ORM;

namespace XLS
{
    public class AverageSpecializationReport
    {
        private DAOExam DAOexam;
        private DAOResult DAOresult;
        private DAOSubgroup DAOsubgroup;
        private DAOSpecialization DAOspecialization;
        public AverageSpecializationReport(DAOFactory factory)
        {
            DAOexam = factory.GetDAOExam();
            DAOresult = factory.GetDAOResult();
            DAOsubgroup = factory.GetDAOSubgroup();
            DAOspecialization = factory.GetDAOSpecialization();
        }

        /// <summary>
        /// Get Header method
        /// </summary>
        /// <returns></returns>
        public List<string> GetHeader()
        {
            return new List<string> { "Специальность", "Средний балл" };
        }

        /// <summary>
        /// Get Data method
        /// </summary>
        /// <returns></returns>
        public List<AverageSpecialization> GetData()
        {
            var exams = DAOexam.ReadAll();
            var results = DAOresult.ReadAll();
            var groups = DAOsubgroup.ReadAll();
            var specializations = DAOspecialization.ReadAll();

            List<AverageSpecialization> averageSpecialtyList = new List<AverageSpecialization>();

            foreach (var val in specializations)
            {
                var marks = from specialization in specializations
                            join grp in groups on specialization.Id equals grp.SpecializationId
                            join exam in exams on grp.Id equals exam.GroupId
                            join result in results on exam.Id equals result.ExamId
                            where val.Id == specialization.Id
                            select result;
                
                var averageResult = marks.Count() != 0 ? marks.Average(x => x.Mark) : 0;
                averageSpecialtyList.Add(new AverageSpecialization
                {
                    SpecializationTitle = val.Title,
                    AverageMark = averageResult
                });
            }

            return averageSpecialtyList;
        }
    }
}
