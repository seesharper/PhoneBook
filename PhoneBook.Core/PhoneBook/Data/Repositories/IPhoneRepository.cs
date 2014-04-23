using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Data.Repositories
{
    public interface IPhoneRepository : IRepository<Phone, int>
    {
        /// <summary>
        /// Deletes all phone numbers for given person id.
        /// </summary>
        /// <param name="personId">Id of the person</param>
        void DeletePhonesOfPerson(int personId);
    }
}