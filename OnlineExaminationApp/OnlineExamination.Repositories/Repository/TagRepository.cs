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
    public class TagRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        
        public List<Tags> GetAllTagses()
        {
            return db.Tagss.ToList();
        }
        public Tags GetTagById(int? tagId)
        {

            return db.Tagss.FirstOrDefault(x => x.Id == tagId);
        }

    }
}
