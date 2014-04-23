using System.Linq;
using Hik.PhoneBook.Data.Entities;

namespace Hik.PhoneBook.Data.Repositories.Nh
{
    public class NhPhoneRepository : NhRepositoryBase<Phone, int>, IPhoneRepository
    {
        public void DeletePhonesOfPerson(int personId)
        {
            var phones = GetAll().Where(phone => phone.PersonId == personId).ToList();
            foreach (var phone in phones)
            {
                Session.Delete(phone);
            }
        }
    }
}