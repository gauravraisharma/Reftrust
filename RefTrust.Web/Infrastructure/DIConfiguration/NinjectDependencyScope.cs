using System.Web.Http;

using Ninject;
using System.Web.Http.Dependencies;
using Ninject.Syntax;
using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using RefTrust.Business.Interfaces;
using RefTrust.Business;

namespace RefTrust.Web.Infrastructure.DIConfiguration
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return resolver.GetAll(serviceType);
        }
    }
}