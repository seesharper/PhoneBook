namespace Hik.PhoneBook.Dependency
{
    using Hik.PhoneBook.BackgroundServices;
    using Hik.PhoneBook.BackgroundServices.Impl;

    using LightInject;

    using NHibernate.Event;

    public class ConsoleCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {

            serviceRegistry.Register<IDeleteOldRecordsService, DeleteOldRecordsService>();
            serviceRegistry.Register<IPeriodicServiceTrigger, PeriodicServiceTrigger>(new PerContainerLifetime());
                                    
        }
    }
}