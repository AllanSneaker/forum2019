using System;
using System.Data.Entity;
using System.Linq;

using ForumEpam2019.Entities.Models;

namespace ForumEpam2019.Entities.Context
{

    public class ForumContext : DbContext
    {
        static ForumContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }
        public ForumContext()
            : base("name=ForumContext")
        {
        }

         public virtual DbSet<ProfileInfo> ProfileInfos { get; set; }
    }

}