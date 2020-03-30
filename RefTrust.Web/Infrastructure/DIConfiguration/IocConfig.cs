using System.Web.Http;

using Ninject;
using System.Web.Http.Dependencies;
using Ninject.Syntax;
using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using RefTrust.Business.Interfaces;
using RefTrust.Business;
using System.Web;
using Ninject.Web.Common;
using System.Reflection;
using RefTrust.Business.Infrastructure;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System.Web.Mvc;
//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RefTrust.Web.Infrastructure.DIConfiguration.IocConfig), "RegisterIoc")]
namespace RefTrust.Web.Infrastructure.DIConfiguration
{
    public static class IocConfig
    {
        //private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void RegisterIoc()
        {
            //DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            //DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            //bootstrapper.Initialize(CreateKernel);
            var kernel = CreateKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/



            // Tell WebApi how to use our Ninject IoC
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(new NinjectMvcDependencyResolver(kernel));

        }
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                DependencyMapper.MapBusinessServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

    }


}