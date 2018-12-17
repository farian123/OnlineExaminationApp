using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class ExamAttendRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(ExamAttend examAttend)
        {
            db.ExamAttends.Add(examAttend);
            return db.SaveChanges() > 0;
        }

        public bool Update(ExamAttend examAttend)
        {
            db.Entry(examAttend).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Delete(int? id)
        {
            ExamAttend examAttend = db.ExamAttends.Find(id);
            db.ExamAttends.Remove(examAttend);
            return db.SaveChanges() > 0;
        }

    }
}
