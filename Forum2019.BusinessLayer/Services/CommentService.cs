using AutoMapper;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Interfaces;
using ForumEpam2019.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using ForumEpam2019_Entities.Models;

namespace ForumEpam2019.BusinessLayer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _autoMapper = Mapper.Instance;
        private IUnitOfWork Database { get; }

        public CommentService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<CommentDto> GetAllComments(int commentId)
        {
            var post = Database.Posts.Get(commentId);

            if (post == null)
                throw new ObjectNotFoundException("Post is null");

            return _autoMapper.Map<IEnumerable<CommentDto>>(Database.Comments.Find(x => x.Post.Id == post.Id));
        }

        public bool AddComment(int postId, CommentDto value)
        {
            if (value == null)
                throw new ArgumentNullException();

            var post = Database.Posts.Get(postId);
            var comment = _autoMapper.Map<Comment>(value);
            comment.Post = post; 
            comment.Author = Database.Authors.Find(x => x.UserName == value.Author).FirstOrDefault();

            Database.Comments.Create(comment);
            Database.Save();
            return true;

        }

        public bool Reply(int commentId, CommentDto value)
        {
            if (value == null)
                throw new ArgumentNullException();

            var parentComment = Database.Comments.Get(commentId);

            if (parentComment == null)
                throw new ObjectNotFoundException("Parent comment not found");

            var comment = _autoMapper.Map<Comment>(value);
            comment.Date = parentComment.Date;
            comment.Post = parentComment.Post;
            comment.Parent = parentComment;
            comment.Content = parentComment.Content;
            comment.Author = Database.Authors.Find(x => x.UserName == value.Author).FirstOrDefault();

            Database.Comments.Create(comment);
            Database.Save();
            return true;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
