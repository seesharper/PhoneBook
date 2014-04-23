namespace Hik.PhoneBook.BackgroundServices
{
    public interface IDeleteOldRecordsService
    {
        void DeletePeopleOlderThan120Age();
    }
}