using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using RefTrust.Web.Models;
using RefTrust.Repository.Entities.Authentication;
using RefTrust.Business.Interfaces;
using System.Web.Http.Description;
using RefTrust.Repository.Entities;
using RefTrust.Repository.Repositories;
using RefTrust.Repository;

namespace RefTrust.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Me")]
    public class MeController : ApiControllerBase
    {
        private ApplicationUserManager _userManager;
        private AuthRepository _repo;
        private RefTrustDBContext db;
       
        public MeController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
            _repo = new AuthRepository();
            db = new RefTrustDBContext();
        }

        // GET: api/Me
        [ResponseType(typeof(UserProfile))]
        public async Task<IHttpActionResult> Get()
        {
            IdentityUser user = await _repo.FindUserByName(User.Identity.Name);
            // UserProfile userProfile =  Uow.UserProfiles.GetById(user.Id);
            UserProfile userProfile = _userBusiness.GetUserProfile(user.Id);

            return Ok(userProfile);
        }

      


        private bool UserProfileExists(string id)
        {
            //return db.UserProfiles.Count(e => e.Id == id) > 0;
            //    return Uow.UserProfiles.GetById(id) != null;
            return true;
        } 
    }
}