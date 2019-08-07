using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Interfaces;
using ForumEpam2019_Entities.Identity.Interfaces;
using ForumEpam2019_Entities.Identity.Models;
using ForumEpam2019_Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ForumEpam2019.BusinessLayer.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWorkIdentity DatabaseIdentity { get; }

        public AccountService(IUnitOfWorkIdentity unitOfWorkIdentity)
        {
            DatabaseIdentity = unitOfWorkIdentity;
        }

        public async Task<OperationDetails> CreateAccount(AccountDto accountDto)
        {
            var user = await DatabaseIdentity.UserService.FindByEmailAsync(accountDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = accountDto.Email, UserName = accountDto.Email };
                var result = await DatabaseIdentity.UserService.CreateAsync(user, accountDto.Password);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                await DatabaseIdentity.UserService.AddToRoleAsync(user.Id, "user");
                Account clientProfile = new Account() { Id = user.Id, UserName = accountDto.UserName };
                DatabaseIdentity.ClientService.Create(clientProfile);
                await DatabaseIdentity.SaveAsync();
                return new OperationDetails(true, "Registration succeeded", "");
            }
            else
            {
                return new OperationDetails(false, "User with same login already exist", "Email");
            }
        }

        public IEnumerable<AccountDto> GetAccounts()
        {
            var appUsers = DatabaseIdentity.UserService.Users;
            var list = new List<AccountDto>();

            if (appUsers != null)
                foreach (var appUser in appUsers)
                    list.Add(CreateUserDto(appUser));

            return list;
        }

        public void Dispose()
        {
            DatabaseIdentity.Dispose();
        }

        public async Task<Tuple<ClaimsIdentity, ClaimsIdentity>> FindAsyncAccount(string username, string password)
        {
            var appUser = await DatabaseIdentity.UserService.FindAsync(username, password);

            if (appUser == null)
                throw new ArgumentException("The user name or password is incorrect.");

            ClaimsIdentity oAuthIdentity = await DatabaseIdentity.UserService.CreateIdentityAsync(appUser, OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await DatabaseIdentity.UserService.CreateIdentityAsync(appUser, CookieAuthenticationDefaults.AuthenticationType);

            return new Tuple<ClaimsIdentity, ClaimsIdentity>(oAuthIdentity, cookiesIdentity);
        }

        public IEnumerable<string> GetRoles()
        {
            return DatabaseIdentity.RoleService.Roles.Select(x => x.Name);
        }

        private AccountDto CreateUserDto(ApplicationUser user)
        {
            return new AccountDto()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.Account.FirstName,
                LastName = user.Account.LastName,
                // Roles = GetRoleForUser(user.Id),
            };
        }

        private string GetRoleForUser(string id)
        {
            var user = DatabaseIdentity.UserService.FindById(id);
            var roleId = user.Roles.Where(x => x.UserId == user.Id).Single().RoleId;
            var role = DatabaseIdentity.RoleService.Roles.Where(x => x.Id == roleId).Single().Name;

            return role;
        }
    }
}
