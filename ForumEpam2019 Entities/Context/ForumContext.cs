using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using ForumEpam2019.Entities.Models;
using ForumEpam2019_Entities.Models;
using ForumEpam2019_Entities.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ForumEpam2019.Entities.Context
{
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

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }

        public virtual DbSet<ProfileInfo> ProfileInfos { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<HashTag> HashTags { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

    }

}