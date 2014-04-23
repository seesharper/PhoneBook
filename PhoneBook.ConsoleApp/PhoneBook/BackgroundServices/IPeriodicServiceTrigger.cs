namespace Hik.PhoneBook.BackgroundServices
{
    public interface IPeriodicServiceTrigger
    {
        void Start();
        void Stop();
    }
}