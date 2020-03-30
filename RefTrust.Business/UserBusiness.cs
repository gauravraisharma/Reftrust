using RefTrust.Business.Interfaces;
using RefTrust.Repository.Entities;
using RefTrust.Repository.Infrastructure.Contract;
using RefTrust.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTrust.Business
{
    public class UserBusiness : UserRepository, IUserBusiness
    {
        private readonly UserRepository userRepository;
        public UserBusiness(IUnitOfWork unit) : base(unit) { userRepository = this; }
        public void NotImplemeted()
        {
            var result = userRepository.GetAll();
        }
        public  UserProfile GetUserProfile(string userId)
        {
            UserProfile userProfile =  userRepository.SingleOrDefault(x => x.Id == userId);
            return userProfile;
        }
    }
}
