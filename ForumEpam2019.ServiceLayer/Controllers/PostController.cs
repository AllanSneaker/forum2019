using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Interfaces;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("api/posts")]
        [AllowAnonymous]
        public HttpResponseMessage GetPosts()
        {
            if (_postService.GetAllPosts().Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, _postService.GetAllPosts());
        }

        [Route("api/posts/{id}")]
        [AllowAnonymous]
        public HttpResponseMessage GetPost(int id)
        {
            if (_postService.PostExist(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, _postService.GetPost(id));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");
            }
        }

        [Route("api/posts")]
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage AddPost([FromBody]PostDto value)
        {
            if (ModelState.IsValid)
            {
                if (_postService.AddPost(value))
                    return Request.CreateResponse(HttpStatusCode.Accepted, "");
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date");
            }
        }

        [Route("api/posts/{id}")]
        [AllowAnonymous]
        public HttpResponseMessage PutPost(int id, [FromBody]PostDto value)
        {
            if (ModelState.IsValid)
            {
                if (_postService.EditPost(value))
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "");
                else
                    return Request.CreateResponse(HttpStatusCode.Accepted, "");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date");
            }
        }

        [Route("api/posts/{id}")]
        [AllowAnonymous]
        public HttpResponseMessage Delete(int id)
        {
            if (_postService.PostExist(id))
            {
                _postService.DeletePost(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");
            }
        }

        new void Dispose()
        {
            _postService.Dispose();
        }
    }
}
