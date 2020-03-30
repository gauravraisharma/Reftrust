using Ninject;
using Ninject.Modules;
using RefTrust.Business.Interfaces;
using RefTrust.Repository.Infrastructure;
using RefTrust.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RefTrust.Business.Infrastructure
{
    public class DependencyMapper
    {
        public static void MapBusinessServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            //kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
            //    .InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IUserBusiness>().To<UserBusiness>();

            // kernel.Bind<IRefTrustUow>().To<RefTrustUow>();
        }
    }
}
