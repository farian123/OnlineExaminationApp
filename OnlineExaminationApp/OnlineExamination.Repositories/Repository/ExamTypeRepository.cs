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
    public class ExamTypeRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        
        public List<ExamType> GetAllExamTypes()
        {
            return db.ExamTypes.ToList();
        }
        public ExamType GetExamTypeById(int? examTypeId)
        {

            return db.ExamTypes.FirstOrDefault(x => x.Id == examTypeId);
        }

    }
}
