using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class ExamRepository
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
        public List<Exam> GetAllExamByCourseId(int courseId)
        {
            return db.Exams.Include(x => x.Courses).Where(x=>x.CourseId==courseId).ToList();
            //return db.Exames.Include(x=>x.Course).Include(x=>x.Organization).ToList();
        }
       

    }
}
