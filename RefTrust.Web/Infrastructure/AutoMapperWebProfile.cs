using RefTrust.Business.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefTrust.Web.Infrastructure
{
    public class AutoMapperWebProfile : AutoMapper.Profile
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutoMapperWebProfile>();
                a.AddProfile<AutoMapperBusinessProfile>();
            });
        }
        protected override void Configure()
        {
            base.Configure();
         
            //Mapping of objects will be going here...........
        }
    }
}