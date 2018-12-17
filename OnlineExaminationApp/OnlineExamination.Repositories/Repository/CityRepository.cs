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
    public class CityRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
       
        public List<City> GetCityByCountryId(int? countryId)
        {
            return db.Cities.Where(x=>x.CountryId==countryId).ToList();
        }
    }
}
