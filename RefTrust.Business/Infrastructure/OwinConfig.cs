using Owin;
using RefTrust.Repository;
using RefTrust.Repository.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTrust.Business.Infrastructure
{
    public class OwinConfig
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(RefTrustDBContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}
