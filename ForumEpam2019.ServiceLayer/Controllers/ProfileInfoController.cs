using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ForumEpam2019.BusinessLayer;
using ForumEpam2019.BusinessLayer.Managers;
using ForumEpam2019.BusinessLayer.Repository;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProfileInfoController : ApiController
    {
        //ProfileInfoManager _repository = new ProfileInfoManager();
        IProfileInfoRepository _repository;

        public ProfileInfoController(IProfileInfoRepository repository)
        {
            _repository = repository;
        }
        //public ProfileInfoController(IProfileInfoRepository repository)
        //{
        //    _repository = repository;
        //}
        [Route("api/profile")]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            if (_repository.GetAllProfileInfos().Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, _repository.GetAllProfileInfos());
        }

        [Route("api/profile/{id}")]
        public HttpResponseMessage Get(int id)
        {
            if (_repository.ProfileInfoExist(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repository.GetProfileInfo(id));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");
            }
        }

        new void Dispose()
        {
            _repository.Dispose();
        }
    }
}
