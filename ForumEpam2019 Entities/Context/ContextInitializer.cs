using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumEpam2019.Entities.Models;

namespace ForumEpam2019.Entities.Context
{
  public  class ContextInitializer : DropCreateDatabaseAlways<ForumContext>
    {
        protected override void Seed(ForumContext context)
        {
            List<ProfileInfo> profiles = new List<ProfileInfo>()
            {
                new ProfileInfo()
                {
                    Age = 10, NickName = "Allan", FullName = "Sneaker", Bio = "Some text"
                },
                new ProfileInfo()
                {
                    Age = 11, NickName = "Ivan", FullName = "Marker", Bio = "Some text"
                },
                new ProfileInfo()
                {
                    Age = 10, NickName = "Oleg", FullName = "Introu", Bio = "Some text"
                },
            };

            context.ProfileInfos.AddRange(profiles);
            context.SaveChanges();
        }
    }
}
