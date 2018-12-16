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
    public class AnswerRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Answer answer)
        {
            db.Answers.Add(answer);
            return db.SaveChanges() > 0;
        }

        public bool Update(Answer answer)
        {
            db.Entry(answer).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
            return db.SaveChanges() > 0;
        }

        public List<Answer> GetAllAnsByQuestionId(int questionId)
        {
            return db.Answers.Where(x => x.QuestionId == questionId).ToList();
        }

        public List<Answer> GetOnlyCurrectAnsByQuessionId(int questionId)
        {
            return db.Answers.Where(x => x.QuestionId == questionId && x.CurrectAns == true).ToList();
        }
    }
}
