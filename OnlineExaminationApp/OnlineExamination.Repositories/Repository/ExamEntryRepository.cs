using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class ExamEntryRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Exam exam)
        {
            db.Exams.Add(exam);
            return db.SaveChanges() > 0;
        }

        public bool Update(Exam exam)
        {
            db.Entry(exam).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            return db.SaveChanges() > 0;
        }
        public List<Exam> GetAllExamEntry()
        {
            return db.Exams.ToList();
        }
        public Exam GetExamEntryById(int? examId)
        {

            return db.Exams.FirstOrDefault(x => x.Id == examId);
        }

        public dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }

        public dynamic GetAllCourse()
        {
            return new SelectList(db.Courses, "Id", "CourseName");
        }

        public dynamic GetSelectedCourse(int id)
        {
            return new SelectList(db.Courses, "Id", "CourseName", id);
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName", id);
        }
    }
}