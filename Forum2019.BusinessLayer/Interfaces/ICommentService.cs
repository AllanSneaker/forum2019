using ForumEpam2019.BusinessLayer.DTO;
using System;
using System.Collections.Generic;

namespace ForumEpam2019.BusinessLayer.Interfaces
{
    public interface ICommentService : IDisposable
    {
        bool AddComment(int postId, CommentDto value);
        bool Reply(int commentId, CommentDto value);
        IEnumerable<CommentDto> GetAllComments(int postId);
    }

}
