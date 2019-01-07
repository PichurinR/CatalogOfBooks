using System.Web.Mvc;
using System.Web.Routing;
using BC.Bootstrap;
using System.Web.Http;

namespace BooksCatalogue
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
    }
}
