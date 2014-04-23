using System.Linq;
using Hik.PhoneBook.Data;
using Hik.PhoneBook.Data.Repositories;
using Hik.PhoneBook.Services;
using System;

namespace Hik.PhoneBook.BackgroundServices.Impl
{
    public class DeleteOldRecordsService : IDeleteOldRecordsService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonService _personService;

        public DeleteOldRecordsService(IPersonRepository personRepository, IPersonService personService)
        {
            _personRepository = personRepository;
            _personService = personService;
        }
        
        [UnitOfWork]
        public void DeletePeopleOlderThan120Age()
        {
            var yearAge120 = DateTime.Now.AddYears(-120);

            var oldRecords = _personRepository.GetAll().Where(person => person.BirthDay < yearAge120).ToList();
            foreach (var oldRecord in oldRecords)
            {
                _personService.DeletePerson(oldRecord.Id);
            }
        }
    }
}