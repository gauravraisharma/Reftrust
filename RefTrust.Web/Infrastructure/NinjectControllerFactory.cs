using Ninject;
using RefTrust.Business.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RefTrust.Web.Infrastructure
{
    public class NinjectControllerFactory1 : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory1()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (controllerType == null) ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            // put additional bindings here
            // ninjectKernel.Bind<...>().To<...>();
            DependencyMapper.MapBusinessServices(ninjectKernel);
        }
    }
}