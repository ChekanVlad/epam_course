﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Exam class
    /// </summary>
    public class Exam
    {
        [Column(IsPrimaryKey=true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }

        [Column(Name = "SubjectType")]
        public string SubjectType { get; set; }

        [Column(Name = "ExamenatorId")]
        public int ExamenatorId { get; set; }

        public Exam(int id, DateTime date, int groupId, int subjectId, string subjectType, int examenatorId)
        {
            Id = id;
            Date = date;
            GroupId = groupId;
            SubjectId = subjectId;
            SubjectType = subjectType;
            ExamenatorId = examenatorId;
        }
        public Exam(DateTime date, int groupId, int subjectId, string subjectType, int examenatorId)
        {
            Date = date;
            GroupId = groupId;
            SubjectId = subjectId;
            SubjectType = subjectType;
            ExamenatorId = examenatorId;
        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Exam exam = obj as Exam;
            if (exam == null)
            {
                return false;
            }

            return Date == exam.Date && GroupId == exam.GroupId && SubjectId == exam.SubjectId && SubjectType == exam.SubjectType && ExamenatorId == exam.ExamenatorId;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 2 * Date.Year + 222 * GroupId + 17 * SubjectId + 16 * ExamenatorId;
        }

    }
}

