using ForumEpam2019.Entities.Context;
using ForumEpam2019_Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Interfaces;
using ForumEpam2019.ServiceLayer.Models;
using ForumEpam2019_Entities.Identity.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        //[Route("api/User/Register")]
        //[HttpPost]
        //[AllowAnonymous]
        //public IdentityResult Register(Account model)
        //{
        //    var userStore = new UserStore<ApplicationUser>(new ForumContext());
        //    var manager = new UserManager<ApplicationUser>(userStore);
        //    var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
        //    user.FirstName = model.FirstName;
        //    user.LastName = model.LastName;
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 3
        //    };
        //    IdentityResult result = manager.Create(user, model.Password);
        //    manager.AddToRoles(user.Id, model.Roles);
        //    return result;
        //}

        //[HttpGet]
        //[Route("api/GetUserClaims")]
        //public Account GetUserClaims()
        //{
        //    var identityClaims = (ClaimsIdentity)User.Identity;
        //    IEnumerable<Claim> claims = identityClaims.Claims;
        //    Account model = new Account()
        //    {
        //        UserName = identityClaims.FindFirst("Username").Value,
        //        Email = identityClaims.FindFirst("Email").Value,
        //        FirstName = identityClaims.FindFirst("FirstName").Value,
        //        LastName = identityClaims.FindFirst("LastName").Value,
        //        LoggedOn = identityClaims.FindFirst("LoggedOn").Value
        //    };
        //    return model;
        //}

        //new version

        readonly IAccountService _accountService;

        IAuthenticationManager Authentication => Request.GetOwinContext().Authentication;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST api/Account/Logout
        [Route("api/Account/Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        // POST api/Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("api/Account/Register")]
        public async Task<IHttpActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var user = new AccountDto() { UserName = model.Email, Email = model.Email, Password = model.Password };
            var result = await _accountService.CreateAccount(user);

            if (!result.Succeeded)
                return BadRequest(result.Message);

            return Ok();
        }

    }
}
