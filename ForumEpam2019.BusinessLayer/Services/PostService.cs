using AutoMapper;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Interfaces;
using ForumEpam2019.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ForumEpam2019_Entities.Models;

namespace ForumEpam2019.BusinessLayer.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _autoMapper = Mapper.Instance;
        IUnitOfWork Database { get; }

        public PostService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        //work
        public IEnumerable<PostDto> GetAllPosts()
        {
            return _autoMapper.Map<IEnumerable<PostDto>>(Database.Posts.GetAll());
        }

        //work
        public PostDto GetPost(int id)
        {
            return _autoMapper.Map<PostDto>(Database.Posts.Get(id));
        }

        //work
        public bool PostExist(int id)
        {
            var order = Database.Posts.Get(id);

            if (order == null)
            {
                throw new ArgumentException("Item not found");

            }
            else
            {
                return true;
            }
        }

        //need to correct
        public bool AddPost(PostDto postDto)
        {
            if (postDto == null)
                throw new ArgumentNullException();

            var post = _autoMapper.Map<Post>(postDto);
            //var post = new Post()
            //{
            //    Author = Database.Authors.Get(postDto.Author.Id),
            //    Content = postDto.Content,
            //    Date = DateTime.Now,
            //    Rate = postDto.Rate,
            //    Title = postDto.Title
            //};

            Database.Posts.Create(post);
            Database.Save();
            return true;
        }

        //need to correct
        public bool EditPost(PostDto value)
        {
            if (value == null)
                throw new ArgumentNullException();

            var tempItem = Database.Posts.Get(value.Id);

            if (tempItem == null)
                throw new ArgumentNullException();

            tempItem.Comments = null;
            tempItem.Content = value.Content;
            //tempItem.HashTags = value.HashTags;
            tempItem.Rate = value.Rate;
            tempItem.Title = value.Title;

            //if (value.Comments.Count == 0)
            //{
            //    Database.Save();
            //}
            //else
            //{
            //    tempItem.Comments = new List<Comment>();
            //    foreach (var comment in value.Comments)
            //        tempItem.Comments.Add(Database.Posts.Create(comment));
            //    Database.Save();
            //}

            Database.Posts.Update(tempItem);
            Database.Save();
            return true;
        }

        //work
        public bool DeletePost(int id)
        {
            var post = Database.Posts.Get(id);

            if (post == null)
                throw new ArgumentNullException();

            Database.Posts.Delete(post.Id);
            Database.Save();
            return true;
        }

        //private ICollection<HashTag> GetHashTags(IEnumerable<string> hashTagNames)
        //{
        //    var hashTags = new List<HashTag>();

        //    foreach (var item in hashTagNames)
        //        hashTags.Add(Database.HashTags.Find(x => x.Name == item).FirstOrDefault() 
        //                     ?? throw new ArgumentException("hashTag not found"));

        //    return hashTags;
        //}

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
