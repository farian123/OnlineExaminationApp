using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class CityManage
    {
        CityRepository _cityRepository = new CityRepository();
        
        public List<City> GetAllCity(int countryId)
        {
            return _cityRepository.GetCityByCountryId(countryId);
        }
    }
}
