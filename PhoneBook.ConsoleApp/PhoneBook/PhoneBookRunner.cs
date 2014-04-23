namespace Hik.PhoneBook
{
    using System;
    using Hik.PhoneBook.BackgroundServices;
    using Hik.PhoneBook.Dependency;
    using LightInject;

    public class PhoneBookRunner : IDisposable
    {
        private IServiceContainer serviceContainer;

        public void Start()
        {
            serviceContainer = new ServiceContainer();
            serviceContainer.RegisterFrom<PhoneBookCompositionRoot>();
            serviceContainer.RegisterFrom<ConsoleCompositionRoot>();
            serviceContainer.GetInstance<IPeriodicServiceTrigger>().Start();            
        }
        
        public void Dispose()
        {
            if (serviceContainer != null)
            {
                serviceContainer.GetInstance<IPeriodicServiceTrigger>().Stop();
                serviceContainer.Dispose();
            }
        }
    }
}