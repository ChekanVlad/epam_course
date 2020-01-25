using System.Collections.Generic;
using System.Linq;
using DAOClasses;
using Microsoft.Office.Interop.Excel;

namespace XLS
{
    /// <summary>
    /// GroupSessionResult class
    /// </summary>
    public class GroupSessionResult
    {
        private static DAOSubgroup DAOgroup;
        private static DAOSubject DAOsubject;
        private static DAOStudent DAOstudent;
        private static DAOExam DAOexam;
        private static DAOResult DAOresult;

        public GroupSessionResult(DAOFactory factory)
        {
            DAOgroup = factory.GetDAOSubgroup();
            DAOsubject = factory.GetDAOSubject();
            DAOstudent = factory.GetDAOStudent();
            DAOexam = factory.GetDAOExam();
            DAOresult = factory.GetDAOResult();
        }

        private List<string> GetHeader()
        {
            return new List<string> { "Fio", "BirthDate", "Gender", "SubjectTitle", "ExamType", "Mark", "Date" };
        }

        /// <summary>
        /// forming result
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public IEnumerable<StudentResult> GetResult(string groupTitle)
        {
            var groups = DAOgroup.ReadAll();
            var subjects = DAOsubject.ReadAll();
            var students = DAOstudent.ReadAll();
            var exams = DAOexam.ReadAll();
            var results = DAOresult.ReadAll();

            var groupWithId = groups.FirstOrDefault(x => x.Title == groupTitle);

            var sessionResults = from student in students
                                 join result in results on student.Id equals result.StudentId
                                 join exam in exams on result.ExamId equals exam.Id
                                 join subject in subjects on exam.SubjectId equals subject.Id
                                 where student.GroupId == groupWithId.Id
                                 select new StudentResult
                                 {
                                     Fio = student.Fio,
                                     BirthDate = student.BirthDate,
                                     Gender = student.Gender,
                                     Date = exam.Date,
                                     SubjectTitle = subject.Title,
                                     ExamType = exam.SubjectType,
                                     Mark = result.Mark
                                 };

            return sessionResults;
        }

        /// <summary>
        /// writing to excel method
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <param name="results"></param>
        public void WriteToExcel(string directory, string fileName, IEnumerable<StudentResult> results)
        {
            var header = GetHeader();
            string path = directory + fileName + ".xlsx";
            var excelApp = new Application();
            Workbook book = excelApp.Workbooks.Add();
            Worksheet sheet = book.Sheets[1];

            for (int i = 1; i < header.Count() + 1; i++)
            {
                sheet.Cells[1, i] = header[i - 1];
            }
            var r = results.GetEnumerator();
            for (int i = 2; i < results.Count(); i++)
            {
                r.MoveNext();
                sheet.Cells[i, 1] = r.Current.Fio;
                sheet.Cells[i, 2] = r.Current.BirthDate.ToString("MM/dd/yyyy");
                sheet.Cells[i, 3] = r.Current.Gender;
                sheet.Cells[i, 4] = r.Current.SubjectTitle;
                sheet.Cells[i, 5] = r.Current.ExamType;
                sheet.Cells[i, 6] = r.Current.Mark;
                sheet.Cells[i, 7] = r.Current.Date;
            }

            book.SaveAs(path);
            book.Close();
            excelApp.Quit();
        }
    }
}

