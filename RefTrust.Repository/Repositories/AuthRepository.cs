
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using RefTrust.Repository.Entities.Authentication;
using RefTrust.Repository.Entities;
using RefTrust.Domain;
using System.Data.Entity.Validation;


namespace RefTrust.Repository.Repositories
{

    public class AuthRepository : IDisposable
    {
        private RefTrustDBContext _ctx;

        private ApplicationUserManager _userManager;

        public AuthRepository()
        {
            _ctx = new RefTrustDBContext();
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_ctx));
        }


        /// This is a quick draft function to create new users
        public void InitAppUser(ApplicationUser applicationUser)
        {
            //get user picture ......
            //var client = new FacebookClient(model.ExternalAccessToken);
            //string request = "me/picture?redirect=false&height=100";
            //var res = client.Get(request);

            var test = (from u in _ctx.UserAvatars
                        where u.Id == "3D874CD2-9F4C-44F3-8D58-0B6E1A1568ED"
                        select u.Avatar).FirstOrDefault();


            applicationUser.UserProfile = new UserProfile
            {
                Id = applicationUser.Id,
                FirstName = "your firstName",
                LastName = "your lastName",
                //BirthDate = NULL,
                Address = "your adresse",
                City = "",
                ZipCode = "",
                Country = "",

                EMailVerified = false,
                MyStatus = "Moving into my new apartment",
                // MyStatusPrivacyLevelId = new Guid("9762CB50-0FF3-4DC5-9942-56033CD2D021"),
                //TermsAndConditionsId  = null,
                //TermsAndConditionsAgreedDate  = NULL,
                DateEntered = DateTime.Now,
                DateModified = DateTime.Now,

                //UserAvatar =
                //new UserAvatar
                //                          {
                //                              Avatar = test,
                //                              DateEntered = DateTime.Now,
                //                              DateModified = DateTime.Now,
                //                          },

                //UserCover =
                //new UserCover
                //                          {
                //                              Cover = test,
                //                              DateEntered = DateTime.Now,
                //                              DateModified = DateTime.Now,
                //                          }
            };
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            ApplicationUser applicationUser = new ApplicationUser { UserName = userModel.UserName, Email = userModel.UserName };


            InitAppUser(applicationUser);
            IdentityResult result = null;
            try { result = await _userManager.CreateAsync(applicationUser, userModel.Password); }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }




            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<ApplicationUser> FindUserByName(string userName)
        {
            return await _ctx.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }

        //public OaConsumer FindClient(string clientId)
        //{
        //    var client = _ctx.OaConsumers.Find(clientId);

        //    return client;
        //}

        //public async Task<bool> AddRefreshToken(RefreshToken token)
        //{

        //   var existingToken = _ctx.OaTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();

        //   if (existingToken != null)
        //   {
        //     var result = await RemoveRefreshToken(existingToken);
        //   }

        //    _ctx.OaTokens.Add(token);

        //    return await _ctx.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        //{
        //   var refreshToken = await _ctx.OaTokens.FindAsync(refreshTokenId);

        //   if (refreshToken != null) {
        //       _ctx.OaTokens.Remove(refreshToken);
        //       return await _ctx.SaveChangesAsync() > 0;
        //   }

        //   return false;
        //}

        //public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        //{
        //    _ctx.OaTokens.Remove(refreshToken);
        //     return await _ctx.SaveChangesAsync() > 0;
        //}

        //public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        //{
        //    var refreshToken = await _ctx.OaTokens.FindAsync(refreshTokenId);

        //    return refreshToken;
        //}

        //public List<RefreshToken> GetAllRefreshTokens()
        //{
        //     return  _ctx.OaTokens.ToList();
        //}

        public async Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo)
        {
            ApplicationUser user = await _userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            InitAppUser(user /*, provider = Facebook*/);

            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}