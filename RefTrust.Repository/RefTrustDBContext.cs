using Microsoft.AspNet.Identity.EntityFramework;
using RefTrust.Repository.Entities;
using RefTrust.Repository.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTrust.Repository
{
    public class RefTrustDBContext : IdentityDbContext<ApplicationUser>
    {
        public RefTrustDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<UserAvatar> UserAvatars { get; set; }
        public virtual DbSet<UserCover> UserCovers { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public static RefTrustDBContext Create()
        {
            return new RefTrustDBContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                  .HasOptional(e => e.UserAvatar)
                  .WithRequired(e => e.UserProfile)
                  .WillCascadeOnDelete();

            modelBuilder.Entity<UserProfile>()
                .HasOptional(e => e.UserCover)
                .WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete();
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}