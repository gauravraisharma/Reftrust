using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using RefTrust.Web.Infrastructure.DIConfiguration;
using System.Web.Http;
using System.Web.Mvc;
using RefTrust.Web.Infrastructure;

[assembly: OwinStartup(typeof(RefTrust.Web.Startup))]

namespace RefTrust.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            IocConfig.RegisterIoc();
            AutoMapperWebProfile.Run();
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ConfigureAuth(app);
        }
    }
}
