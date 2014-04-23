using System.Collections.Generic;
using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Services
{
    public interface IPhoneService
    {
        List<Phone> GetPhoneListOfPerson(int personId);
        
        void CreatePhone(Phone phone);

        void UpdatePhone(Phone phone);

        void DeletePhone(int personId);
    }
}