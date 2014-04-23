using System.Collections.Generic;
using System.Linq;
using Hik.PhoneBook.Data;
using Hik.PhoneBook.Data.Entities;
using Hik.PhoneBook.Data.Repositories;

namespace Hik.PhoneBook.Services.Impl
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository personRepository)
        {
            _cityRepository = personRepository;
        }

        [UnitOfWork]
        public List<City> GetCityList()
        {
            /* Used UnitOfWork attribute, because GetAll method returns IQueryable<City>, it does not fetches records from database. 
             * No database operation is performed until ToList(). Thus, we need to control connection open/close in this method using UnitOfWork. */
            return _cityRepository.GetAll().OrderBy(city => city.Name).ToList();
        }
    }
}