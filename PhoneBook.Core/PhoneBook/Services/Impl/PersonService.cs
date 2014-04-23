using System.Collections.Generic;
using System.Linq;
using Hik.PhoneBook.Data;
using Hik.PhoneBook.Data.Entities;
using Hik.PhoneBook.Data.Repositories;

namespace Hik.PhoneBook.Services.Impl
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        private readonly IPhoneRepository _phoneRepository;

        public PersonService(IPersonRepository personRepository, IPhoneRepository phoneRepository)
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
        }
        
        [UnitOfWork]
        public List<Person> GetPeopleList()
        {
            /* Used UnitOfWork attribute, because GetAll method returns IQueryable<Person>, it does not fetches records from database. 
             * No database operation is performed until ToList(). Thus, we need to control connection open/close in this method using UnitOfWork. */
            return _personRepository.GetAll().OrderBy(person => person.Name).ToList();
        }

        public void CreatePerson(Person person)
        {
            /* Not used UnitOfWork attribute, because this method only calls one repository method and repoository can manage it's connection/transaction. */
            _personRepository.Insert(person);
        }

        public void UpdatePerson(Person person)
        {
            /* Not used UnitOfWork attribute, because this method only calls one repository method and repoository can manage it's connection/transaction. */
            _personRepository.Update(person);
        }

        [UnitOfWork]
        public void DeletePerson(int personId)
        {
            /* Used UnitOfWork attribute, because we use different repositories and all operations must be transactional. */
            _personRepository.Delete(personId);
            _phoneRepository.DeletePhonesOfPerson(personId);
        }
    }
}