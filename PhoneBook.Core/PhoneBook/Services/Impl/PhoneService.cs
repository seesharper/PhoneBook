using System.Collections.Generic;
using System.Linq;
using Hik.PhoneBook.Data;
using Hik.PhoneBook.Data.Entities;
using Hik.PhoneBook.Data.Repositories;

namespace Hik.PhoneBook.Services.Impl
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        [UnitOfWork]
        public List<Phone> GetPhoneListOfPerson(int personId)
        {
            /* Used UnitOfWork attribute, because GetAll method returns IQueryable<Phone>, it does not fetches records from database. 
             * No database operation is performed until ToList(). Thus, we need to control connection open/close in this method using UnitOfWork. */
            return _phoneRepository.GetAll().Where(phone => phone.PersonId == personId).ToList();
        }

        public void CreatePhone(Phone phone)
        {
            /* Not used UnitOfWork attribute, because this method only calls one repository method and repoository can manage it's connection/transaction. */
            _phoneRepository.Insert(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            /* Not used UnitOfWork attribute, because this method only calls one repository method and repoository can manage it's connection/transaction. */
            _phoneRepository.Update(phone);
        }

        public void DeletePhone(int personId)
        {
            /* Not used UnitOfWork attribute, because this method only calls one repository method and repoository can manage it's connection/transaction. */
            _phoneRepository.Delete(personId);
        }
    }
}