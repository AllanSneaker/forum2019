using ForumEpam2019.Entities.Context;
using ForumEpam2019_Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class AccountController : ApiController
    {
        readonly IAccountService _accountService;
        IAuthenticationManager Authentication => Request.GetOwinContext().Authentication;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
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
            manager.AddToRoles(user.Id, model.Roles);
            return result;
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        public Account GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            Account model = new Account()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }

        //new version

        [Route("api/users")]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage GetUsers()
        {
            if (_accountService.GetAccounts().Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, _accountService.GetAccounts());
        }

        [HttpPost]
        [Route("api/Account/Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

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
