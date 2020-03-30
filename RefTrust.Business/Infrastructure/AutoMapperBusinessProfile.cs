using RefTrust.Domain;
using RefTrust.Repository.Entities;
using RefTrust.Repository.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTrust.Business.Infrastructure
{
    public class AutoMapperBusinessProfile : AutoMapper.Profile
    {
        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutoMapperBusinessProfile>();
            });
        }
        protected override void Configure()
        {
            base.Configure();
            #region business to entity
         
            AutoMapper.Mapper.CreateMap<UserProfile, UserProfileModel>();

            #endregion
           


        }
    }
}
