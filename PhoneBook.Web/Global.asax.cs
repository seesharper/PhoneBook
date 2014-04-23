using System.Web;
using LightInject;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Hik.PhoneBook.Dependency;
using PhoneBook.Web;

namespace Hik.PhoneBook.Web
{
    

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        
        private IServiceContainer serviceContainer;

        protected void Application_Start()
        {
            serviceContainer = new ServiceContainer();
            serviceContainer.RegisterFrom<PhoneBookCompositionRoot>();
            serviceContainer.RegisterControllers();
            serviceContainer.EnableMvc();
                       
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            if (serviceContainer != null)
            {
                serviceContainer.Dispose();
            }
        }      
    }
}