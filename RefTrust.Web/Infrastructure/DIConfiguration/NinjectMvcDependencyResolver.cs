﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefTrust.Web.Infrastructure.DIConfiguration
{
    public class NinjectMvcDependencyResolver : NinjectDependencyScope,
                                            System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectMvcDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }
    }
}