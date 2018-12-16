using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class AnswerTypeRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public List<AnswerType> GetAllAnswerType()
        {
            return db.AnswerTypes.ToList();
            //return db.Batches.Include(x=>x.Course).Include(x=>x.Organization).ToList();
        }

        public AnswerType GetAllAnswerTypeById(int answerTypeId)
        {
            return db.AnswerTypes.Find(answerTypeId);
        }
    }
}
