using System.Collections.Generic;
using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Services
{
    public interface IPersonService
    {
        List<Person> GetPeopleList();
        
        void CreatePerson(Person person);

        void UpdatePerson(Person person);
        
        void DeletePerson(int personId);
    }
}
