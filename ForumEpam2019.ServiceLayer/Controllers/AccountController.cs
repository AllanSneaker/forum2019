﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ForumEpam2019_Entities.Models;
using ForumEpam2019.Entities.Context;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        public IdentityResult Register(Account model)
        {
            var userStore = new UserStore<ApplicationUser>(new ForumContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            return result;
        }
    }
}
