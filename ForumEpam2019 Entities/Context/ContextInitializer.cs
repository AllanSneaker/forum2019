using System;
using ForumEpam2019.Entities.Models;
using ForumEpam2019_Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ForumEpam2019.Entities.Context
{
    public class ContextInitializer : DropCreateDatabaseAlways<ForumContext>
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

            Author author = new Author(){UserName = "Tanaka"};
            context.Authors.Add(author);

            Comment comment = new Comment()
            {
                Author = author,
                Content = "Content",
                Date = DateTime.Parse("08-01-2019")
            };
            context.Comments.Add(comment);

            HashTag hashTag = new HashTag(){Name = "FindMe"};
            HashTag hashTag2 = new HashTag() { Name = "Thx" };

            context.HashTags.Add(hashTag);
            context.HashTags.Add(hashTag2);

            Post post = new Post()
            {
                Author = new Author(){UserName = "Ivan"},
                Title = "Post",
                Rate = 5,
                Date = DateTime.Parse("08-01-2019"),
                Comments = new List<Comment>() { comment },
                HashTags = new List<HashTag>() { hashTag }

            };

            Post post2 = new Post()
            {
                Author = new Author() { UserName = "Oleg" },
                Title = "Post",
                Rate = 5,
                Date = DateTime.Parse("08-01-2019"),
                Comments = new List<Comment>() { comment },
                HashTags = new List<HashTag>() { hashTag2 }

            };

            context.Posts.Add(post);
            context.Posts.Add(post2);



            //IdentityRole role1 = new IdentityRole() { Name = "Admin" };
            //IdentityRole role2 = new IdentityRole() { Name = "Moder" };
            //IdentityRole role3 = new IdentityRole() { Name = "User" };
            //context.Roles.Add(role1);
            //context.Roles.Add(role2);
            //context.Roles.Add(role3);

            string[] commands =
            {
                @"INSERT INTO [dbo].[Role] ([Id] ,[Name] ,[Discriminator]) VALUES ('9c39f82e-c87b-4bfb-b786-eec87ac45744','admin','ApplicationRole')",
                @"INSERT INTO [dbo].[Role] ([Id] ,[Name] ,[Discriminator]) VALUES ('3b25e968-41c8-48cd-bd65-7f235b5c209e','user','ApplicationRole')",
                @"INSERT INTO [dbo].[Role] ([Id] ,[Name] ,[Discriminator]) VALUES ('cb25e968-4dc8-48cd-ac65-7f230a5c209e','moderator','ApplicationRole')",
                @"INSERT INTO [dbo].[User] ([Id] ,[Email] ,[EmailConfirmed] ,[PasswordHash] ,[SecurityStamp] ,[PhoneNumber] ,[PhoneNumberConfirmed] ,[TwoFactorEnabled],[LockoutEndDateUtc] ,[LockoutEnabled] ,[AccessFailedCount] ,[UserName]) 
                    VALUES ('f0e55c71-2e6c-41df-bea1-1ff5dc102f59' ,'admin@gmail.com' ,0 ,'AGWw56+JXBJWPXED3BLTjDmPM5/166S/TuwnjGG842sBb1a967GidG+05UWJRukNXw==' ,'1c52b5dd-622b-47a6-b426-46e4751c548b',NULL ,0 ,0 ,NULL ,0 ,0 ,'admin@gmail.com')", //password = "adminpassword"
                //@"INSERT INTO [dbo].[Accounts] ([Id], [Name]) VALUES ('f0e55c71-2e6c-41df-bea1-1ff5dc102f59', 'Admin')",
                @"INSERT INTO [dbo].[UserRole] ([UserId] ,[RoleId]) VALUES ('f0e55c71-2e6c-41df-bea1-1ff5dc102f59', '9c39f82e-c87b-4bfb-b786-eec87ac45744')",

            };

            foreach (var el in commands)
                context.Database.ExecuteSqlCommand(el);

            context.SaveChanges();
        }
    }
}
