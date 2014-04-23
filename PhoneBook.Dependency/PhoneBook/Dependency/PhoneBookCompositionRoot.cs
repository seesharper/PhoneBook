namespace Hik.PhoneBook.Dependency
{
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using Hik.PhoneBook.Data;
    using Hik.PhoneBook.Data.Repositories.Nh;
    using Hik.PhoneBook.Data.Repositories.Nh.Mappings;
    using Hik.PhoneBook.Dependency.Uow;
    using Hik.PhoneBook.Services.Impl;

    using LightInject;

    using NHibernate;

    public class PhoneBookCompositionRoot :  ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register(f => CreateNhSessionFactory(), new PerContainerLifetime());

            serviceRegistry.RegisterAssembly(typeof(NhPersonRepository).Assembly);

            serviceRegistry.RegisterAssembly(typeof(PersonService).Assembly);

            serviceRegistry.Register<UnitOfWorkInterceptor>();

            serviceRegistry.Intercept(sr => sr.ImplementingType != null && sr.ImplementingType.GetMethods().Any(m => m.IsDefined(typeof(UnitOfWorkAttribute), true)), f => f.GetInstance<UnitOfWorkInterceptor>());
        }

        
        


        /// <summary>
        /// Creates NHibernate Session Factory.
        /// </summary>
        /// <returns>NHibernate Session Factory</returns>
        private static ISessionFactory CreateNhSessionFactory()
        {
            var connStr = ConfigurationManager.ConnectionStrings["PhoneBook"].ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(PersonMap))))
                .BuildSessionFactory();
        }
    }
}