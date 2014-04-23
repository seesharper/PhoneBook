using System;
using System.Timers;
namespace Hik.PhoneBook.BackgroundServices.Impl
{
    public class PeriodicServiceTrigger : IPeriodicServiceTrigger
    {
        private readonly IDeleteOldRecordsService _deleteOldRecordsService;

        private readonly Timer _timer;

        public PeriodicServiceTrigger(IDeleteOldRecordsService deleteOldRecordsService)
        {
            _deleteOldRecordsService = deleteOldRecordsService;

            _timer = new Timer(10000);
            _timer.Elapsed += Timer_Elapsed;
        }

        public void Start()
        {
            _timer.Start();
            Console.WriteLine("Started service: OldRecordDeleteService");
        }

        public void Stop()
        {
            _timer.Stop();
            Console.WriteLine("Stopped service: OldRecordDeleteService");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {           
            try
            {
                _deleteOldRecordsService.DeletePeopleOlderThan120Age();
            }
            catch(Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}