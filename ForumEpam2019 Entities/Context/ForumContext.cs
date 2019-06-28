using System;
using System.Data.Entity;
using System.Linq;

using ForumEpam2019.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ForumEpam2019.Entities.Context
{

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ForumContext : IdentityDbContext<ApplicationUser>
    {
        static ForumContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }
        public ForumContext()
            : base("name=ForumContext", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AspNetUsers -> User
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
            //AspNetRoles -> Role
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            //AspNetUserRoles -> UserRole
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");
            //AspNetUserClaims -> UserClaim
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            //AspNetUserLogins -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");
        }

        public virtual DbSet<ProfileInfo> ProfileInfos { get; set; }

    }

}