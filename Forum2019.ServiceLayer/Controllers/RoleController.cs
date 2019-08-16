using System.Collections.Generic;
using ForumEpam2019.Entities.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ForumEpam2019.BusinessLayer.Interfaces;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _autoMapper = Mapper.Instance;

        public RoleController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //[HttpGet]
        //[Route("api/roles")]
        //[Authorize(Roles = "admin")]
        //public IEnumerable<string> GetRoles()
        //{
        //    return _accountService.GetRoles();
        //}

        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new ForumContext());
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }
    }
}
