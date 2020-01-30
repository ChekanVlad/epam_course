using System.Collections.Generic;
using System.Linq;
using DAOClasses;
using ORM;

namespace XLS
{
    /// <summary>
    /// Class for getting data.
    /// </summary>
    public class AverageExaminatorReport
    {
        private DAOExam DAOexam;
        private DAOResult DAOresult;
        private DAOExaminator DAOexaminator;
        public AverageExaminatorReport(DAOFactory factory)
        {
            DAOexam = factory.GetDAOExam();
            DAOresult = factory.GetDAOResult();
            DAOexaminator = factory.GetDAOExaminator();
        }

        /// <summary>
        /// Get Header method
        /// </summary>
        /// <returns></returns>
        public List<string> GetHeader()
        {
            return new List<string> { "Examinator", "Average mark" };
        }

        /// <summary>
        /// get data method
        /// </summary>
        /// <returns></returns>
        public List<AverageExaminator> GetData()
        {
            var exams = DAOexam.ReadAll();
            var results = DAOresult.ReadAll();
            var examinators = DAOexaminator.ReadAll();

            List<AverageExaminator> averageExaminatorList = new List<AverageExaminator>();

            foreach (var val in examinators)
            {
                var marks = from result in results
                            join exam in exams on result.ExamId equals exam.Id
                            join examinator in examinators on exam.ExaminatorId equals examinator.Id
                            where examinator.Id == val.Id
                            select result;
                
                var averageResult = marks.Count() != 0 ? marks.Average(x => x.Mark) : 0;
                averageExaminatorList.Add(new AverageExaminator
                {
                    ExaminatorFio = val.Fio,
                    AverageMark = averageResult
                });
            }

            return averageExaminatorList;
        }
    }
}
