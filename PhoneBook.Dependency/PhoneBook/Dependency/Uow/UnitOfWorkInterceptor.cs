namespace Hik.PhoneBook.Dependency.Uow
{
    using System;
    using System.Reflection;

    using Hik.PhoneBook.Data.Repositories.Nh;

    using LightInject.Interception;

    using NHibernate;

    using IInterceptor = LightInject.Interception.IInterceptor;

    public class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly ISessionFactory sessionFactory;

        public UnitOfWorkInterceptor(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public object Invoke(IInvocationInfo invocationInfo)
        {
            //If there is a running transaction, just run the method
            if (NhUnitOfWork.Current != null)
            {
                return invocationInfo.Proceed();                
            }

            object returnValue;
            try
            {
                NhUnitOfWork.Current = new NhUnitOfWork(sessionFactory);
                NhUnitOfWork.Current.BeginTransaction();                
                try
                {
                    returnValue = invocationInfo.Proceed();
                    NhUnitOfWork.Current.Commit();

                }
                catch (Exception)
                {
                    try
                    {
                        NhUnitOfWork.Current.Rollback();
                    }
                    catch (Exception)
                    {
                      
                    }
                    
                    throw;
                }
            }
            finally
            {
                NhUnitOfWork.Current = null;
            }
            return returnValue;
        }       
    }
}