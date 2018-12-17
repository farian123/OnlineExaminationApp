using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class QuestionRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Question question)
        {
            db.Questions.Add(question);
            return db.SaveChanges() > 0;
        }

        public bool Update(Question question)
        {
            db.Entry(question).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Question question = db.Questions.Find(id);
            if (question != null) db.Questions.Remove(question);
            return db.SaveChanges() > 0;
        }
        public List<Question> GetAllQuestionAnswer()
        {
            return db.Questions.ToList();
        }
        public Question GetQuestionAnswerById(int? questionAnswerId)
        {

            return db.Questions.FirstOrDefault(x => x.Id == questionAnswerId);
        }

        public dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }
        public dynamic GetAllCourse()
        {
            return new SelectList(db.Courses, "Id", "CourseName");
        }
        public dynamic GetAllExam()
        {
            return new SelectList(db.Exams, "Id", "ExamType");
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName", id);
        }
        public dynamic GetSelectedCourse(int id)
        {
            return new SelectList(db.Courses, "Id", "CourseName", id);
        }
        public dynamic GetSelectedExam(int id)
        {
            return new SelectList(db.Exams, "Id", "ExamType", id);
        }

        public dynamic GetSelectedBatch(int id)
        {
            return new SelectList(db.Exams, "Id", "BatchNo", id);
        }

        public dynamic GetAllBatch()
        {
            return new SelectList(db.Batches, "Id", "BatchNo");
        }
        public List<Question> GetAllQuestionByExamId(int examId)
        {
            return db.Questions.Where(x => x.ExamId == examId).ToList();
        }

        public IQueryable<Question> GetQuestionOneByExamId(int examId,int skipNu)
        {
            return db.Questions.Where(x => x.ExamId == examId).OrderBy(x=>x.Id).Skip(skipNu).Take(1);
        }

       
    }
}