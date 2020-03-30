using RefTrust.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefTrust.Repository.Infrastructure;
using RefTrust.Repository.Entities;
namespace RefTrust.Repository.Repositories
{
    public class UserRepository : BaseRepository<UserProfile>
    {
       public UserRepository(IUnitOfWork unit)
            : base(unit)
        {

        }
    }
}
