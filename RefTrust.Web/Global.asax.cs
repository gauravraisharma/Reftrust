using Ninject;
using Ninject.Web.Common;
using RefTrust.Business;
using RefTrust.Business.Interfaces;
using RefTrust.Web.Infrastructure;
using RefTrust.Web.Infrastructure.DIConfiguration;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RefTrust.Web
{
    public class MvcApplication : HttpApplication
    {
      
        protected void Application_Start()
        {
            
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
