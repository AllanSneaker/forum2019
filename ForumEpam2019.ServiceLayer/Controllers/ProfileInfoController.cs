using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ForumEpam2019.BusinessLayer.Managers;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProfileInfoController : ApiController
    {
        ProfileInfoManager manager = new ProfileInfoManager();

        [Route("api/profile")]
        public HttpResponseMessage Get()
        {
            if (manager.GetAllProfileInfos().Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, manager.GetAllProfileInfos());
        }

        [Route("api/profile/{id}")]
        public HttpResponseMessage Get(int id)
        {
            if (manager.ProfileInfoExist(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, manager.GetProfileInfo(id));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");
            }
        }

        new void Dispose()
        {
            manager.Dispose();
        }
    }
}
