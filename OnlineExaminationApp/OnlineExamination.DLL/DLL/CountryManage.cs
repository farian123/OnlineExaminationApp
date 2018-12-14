using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class CountryManage
    {
        CountryRepository _countryRepository = new CountryRepository();

        public List<Country> GetAllCountry()
        {
            return _countryRepository.GetAllCountry();
        }
    }
}
