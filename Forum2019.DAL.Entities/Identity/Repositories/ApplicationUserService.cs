using ForumEpam2019_Entities.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ForumEpam2019_Entities.Identity.Repositories
{
    public class ApplicationUserService : UserManager<ApplicationUser>
    {
        public ApplicationUserService(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserService Create(IdentityFactoryOptions<ApplicationUserService> options)
        {
            var manager = new ApplicationUserService(new UserStore<ApplicationUser>(/*DATACONTEXT*/));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                //RequireNonLetterOrDigit = true,
                //RequireDigit = true,
                //RequireLowercase = true,
                //RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
