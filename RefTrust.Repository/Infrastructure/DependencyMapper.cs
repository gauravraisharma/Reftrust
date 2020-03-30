using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RefTrust.Repository.Infrastructure
{
    public class DependencyMapper
    {
        public static void MapBusinessServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            //kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
            //    .InSingletonScope();

            //kernel.Bind<IUserRepo>().To<UserBusiness>();
            // kernel.Bind<IRefTrustUow>().To<RefTrustUow>();
        }
    }
}
