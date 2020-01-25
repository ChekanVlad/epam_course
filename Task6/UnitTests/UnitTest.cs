using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM;
using DAOClasses;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        private static string connectionString = "server=localhost;user=root;database=task6;password=G8129307csgo;";
        private DAOFactory factory = DAOFactory.GetInstance(connectionString);
        private Random random = new Random();
        /// <summary>
        /// Test
        /// </summary>
        [TestMethod]
        public void Create_Read_Update_Test()
        {
            DAOSubject subject = factory.GetDAOSubject();
            Subject testSubject = new Subject("TestSubject");
            subject.Create(testSubject);
            Subject readedSubject = subject.Read(subject.ReadAll()[subject.ReadAll().Count-1].Id);
            Assert.IsTrue(testSubject.Equals(readedSubject));
            
            Subject newSubject = new Subject("UpdatedSubject");
            subject.Update(newSubject, subject.ReadAll()[subject.ReadAll().Count-1].Id);
            Subject updatedSubject = subject.Read(subject.ReadAll()[subject.ReadAll().Count-1].Id);
            Assert.IsTrue(newSubject.Equals(updatedSubject));

            subject.Delete(subject.ReadAll()[subject.ReadAll().Count - 1].Id);
            readedSubject = subject.Read(subject.ReadAll()[subject.ReadAll().Count - 1].Id);
            Assert.IsFalse(newSubject.Equals(readedSubject));
        }

        /// <summary>
        /// Insert method
        /// </summary>
        [TestMethod]
        public void Insert()
        {
            DAOSubgroup subgroup = factory.GetDAOSubgroup();
            DAOSubject subject = factory.GetDAOSubject();
            DAOStudent student = factory.GetDAOStudent();
            DAOExam exam = factory.GetDAOExam();
            DAOResult result = factory.GetDAOResult();
            string[] subgroupsNames = { "ИТ", "ИП", "ЭС", "ЭФ", "ЭП"};
            string[] subjectsNames = { "Математика", "ООП", "АОСКГ", "Компьютерные сети", 
                "Философия", "Политология", "История", "Нейронные сети", "ВСРПП" };
            string[] tables = { "groups","subjects","students","exams","results"};
            string[] names = { "First","Second","Third","Fourth","Fifth","Sixth","Seventh",
                        "Eighth","Ninth","Tenth","Eleventh","Twelfth","Thirteenth","Fourteenth","Fifteenth"};

            for (int i = 0; i < subgroupsNames.Length; i++)
            {
                subgroup.Create(new Subgroup(subgroupsNames[i]));
            }

            for(int i = 0; i < subjectsNames.Length; i++)
            {
                subject.Create(new Subject(subjectsNames[i]));
            }

            for (int k = 0; k < subgroupsNames.Length; k++)
            {
                for(int i = 0; i < 15; i++)
                {
                    string name = names[random.Next(names.Length)] + random.Next(100);
                    string gender = random.NextDouble() > 0.5 ? "male" : "female";
                    student.Create(new Student(name, k+1, gender,
                        new DateTime(random.Next(1998, 2000), random.Next(1, 12), random.Next(1, 28))));
                }
            }

            for (int i = 0; i < 20; i++)
            {
                string subjecType = random.NextDouble() > 0.5 ? "test" : "exam";
                exam.Create(new Exam(new DateTime(random.Next(1998, 2000), random.Next(1, 12), random.Next(1, 28)),
                random.Next(1, random.Next(1, subgroupsNames.Length + 1)),
                random.Next(1, random.Next(1, subjectsNames.Length + 1)), "Markable"
                ));
            }

            List<Student> students = student.ReadAll();
            List<Exam> exams = exam.ReadAll();
            for(int i = 0; i < students.Count; i++)
            {
                for(int k = 0; k < exams.Count; k++)
                {
                    if(students[i].GroupId == exams[k].GroupId)
                    result.Create(new Result(students[i].Id, exams[k].Id, random.Next(1,11)));
                }
            }
        }
    }
}
