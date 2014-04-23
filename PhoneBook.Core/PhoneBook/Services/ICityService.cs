using System.Collections.Generic;
using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Services
{
    public interface ICityService
    {
        List<City> GetCityList();
    }
}