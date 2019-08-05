using ForumEpam2019.BusinessLayer.Interfaces;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ForumEpam2019.BusinessLayer.DTO;

namespace ForumEpam2019.ServiceLayer.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("api/posts/{id}/comments")]
        [AllowAnonymous]
        public HttpResponseMessage GetComments(int id)
        {
            if (_commentService.GetAllComments(id).Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, _commentService.GetAllComments(id));
        }

        [Route("api/posts/{id}/comments")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage PostAddComment(int postId, [FromBody]CommentDto value)
        {
            if (ModelState.IsValid)
            {
                if (_commentService.AddComment(postId, value))
                    return Request.CreateResponse(HttpStatusCode.Accepted, "Comment added");
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date");
            }
        }

        [Route("api/comments/{commentId}/comments")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage ReplyComment(int postId, [FromBody]CommentDto value)
        {
            if (ModelState.IsValid)
            {
                if (_commentService.Reply(postId, value))
                    return Request.CreateResponse(HttpStatusCode.Accepted, "Reply added");
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date");
            }
        }

    }
}
