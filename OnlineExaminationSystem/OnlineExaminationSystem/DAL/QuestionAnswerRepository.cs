using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationSystem.DAL
{
    public class QuestionAnswerRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(QuestionMark participant)
        {
            db.QuestionMarks.Add(participant);
            return db.SaveChanges() > 0;
        }

        public bool Update(QuestionMark participant)
        {
            db.Entry(participant).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            QuestionMark participant = db.QuestionMarks.Find(id);
            db.QuestionMarks.Remove(participant);
            return db.SaveChanges() > 0;
        }
        public List<QuestionMark> GetAllQuestionAnswer()
        {
            return db.QuestionMarks.ToList();
        }
        public QuestionMark GetQuestionMarkById(int? participantId)
        {

            return db.QuestionMarks.FirstOrDefault(x => x.Id == participantId);
        }

        internal dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }
        internal dynamic GetAllCourse()
        {
            return new SelectList(db.Courses, "Id", "CourseName");
        }
        internal dynamic GetAllExam()
        {
            return new SelectList(db.Exams, "Id", "ExamType");
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName", id);
        }
        internal dynamic GetSelectedCourse(int id)
        {
            return new SelectList(db.Courses, "Id", "CourseName", id);
        }
        internal dynamic GetSelectedExam(int id)
        {
            return new SelectList(db.Exams, "Id", "ExamType", id);
        }
    }
}