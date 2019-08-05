using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ForumEpam2019.BusinessLayer.Interfaces;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProfileInfoController : ApiController
    {
        private readonly IProfileInfoService _service;

        public ProfileInfoController(IProfileInfoService service)
        {
            _service = service;
        }

        [Route("api/profile")]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            if (_service.GetAllProfileInfos().Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, _service.GetAllProfileInfos());
        }

        [Route("api/profile/{id}")]
        public HttpResponseMessage Get(int id)
        {
            if (_service.ProfileInfoExist(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, _service.GetProfileInfo(id));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");
            }
        }

        new void Dispose()
        {
            _service.Dispose();
        }
    }
}
