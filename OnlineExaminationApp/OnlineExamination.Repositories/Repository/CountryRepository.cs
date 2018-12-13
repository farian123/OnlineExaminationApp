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
    public class CountryRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public List<Country> GetAllCountry()
        {
            return db.Countries.ToList();
            //return db.Batches.Include(x=>x.Course).Include(x=>x.Organization).ToList();
        }
       
    }
}
