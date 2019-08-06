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

        public IEnumerable<PostDto> GetAllPosts()
        {
            return _autoMapper.Map<IEnumerable<PostDto>>(Database.Posts.GetAll());
        }

        public PostDto GetPost(int id)
        {
            return _autoMapper.Map<PostDto>(Database.Posts.Get(id));
        }

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

        public bool AddPost(PostDto postDto)
        {
            if (postDto == null)
                throw new ArgumentNullException();

            var hashTags = _autoMapper.Map<ICollection<HashTagDto>, ICollection<HashTag>>(postDto.HashTags);

            var post = _autoMapper.Map<Post>(postDto);
            post.Author = Database.Authors.Find(x => x.UserName == postDto.Author).FirstOrDefault();
            post.Content = postDto.Content;
            post.Date = DateTime.Now;
            post.Rate = postDto.Rate;
            post.Title = postDto.Title;
            post.HashTags = hashTags;

            foreach (var tag in postDto.HashTags)
                post.HashTags.Add(Database.HashTags.Get(GetTag(tag.Name)));

            Database.Posts.Create(post);
            Database.Save();
            return true;
        }

        public bool EditPost(PostDto value)
        {
            if (value == null)
                throw new ArgumentNullException();

            var post = Database.Posts.Get(value.Id);

            post.Title = value.Title;
            post.Content = value.Content;

            Database.Posts.Update(post);
            Database.Save();
            return true;
        }

        public bool DeletePost(int id)
        {
            var post = Database.Posts.Get(id);

            if (post == null)
                throw new ArgumentNullException();

            Database.Posts.Delete(post.Id);
            Database.Save();
            return true;
        }

        public void AddTags(int postId, params string[] tags)
        {
            if (tags == null)
                throw new ArgumentNullException();

            var post = Database.Posts.Get(postId);

            post.HashTags.Clear();

            foreach (var tag in tags)
                if (string.IsNullOrWhiteSpace(tag))
                    continue;
                else
                    post.HashTags.Add(Database.HashTags.Get(GetTag((tag.Trim()))));

            Database.Posts.Update(post);
            Database.Save();
        }

        //public string[] GetTags()
        //{
        //    return Database.HashTags.GetAll().Select(x => x.Name).ToArray();
        //}

        private int GetTag(string name)
        {
            name = name.ToLower();
            var tag = Database.HashTags.Find(x => x.Name.ToLower() == name).FirstOrDefault();

            if (tag == null)
                Database.HashTags.Create(new HashTag() { Name = name });

            Database.Save();
            return Database.HashTags.Find(x => x.Name == name).FirstOrDefault().Id;
        }

        public IEnumerable<PostDto> SearchPostByHashTag(params string[] tags)
        {
            var posts = new List<Post>();

            if (tags == null)
                return new List<PostDto>();

            foreach (var tag in tags)
            {
                if (string.IsNullOrWhiteSpace(tag))
                    continue;

                var t = Database.HashTags.Find(x => x.Name.ToLower() == tag.ToLower()).FirstOrDefault();

                //if tag do not exist or do not have post
                if (t == null || t.Posts.Count == 0)
                {
                    posts.Clear();
                    break;
                }

                if (posts.Count <= 0)
                    posts = t.Posts.ToList();
                else
                    posts = (t.Posts).Intersect(posts).ToList();
            }

            return _autoMapper.Map<IEnumerable<PostDto>>(posts);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
