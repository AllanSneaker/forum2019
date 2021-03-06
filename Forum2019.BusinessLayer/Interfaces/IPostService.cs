﻿using ForumEpam2019.BusinessLayer.DTO;
using System;
using System.Collections.Generic;

namespace ForumEpam2019.BusinessLayer.Interfaces
{
    public interface IPostService : IDisposable
    {
        IEnumerable<PostDto> GetAllPosts();
        PostDto GetPost(int id);
        bool AddPost(PostDto postDto);
        bool EditPost(PostDto value);
        bool DeletePost(int id);
        bool PostExist(int id);
        void AddTags(int postId, params string[] tags);
        IEnumerable<PostDto> SearchPostByHashTag(params string[] tags);
    }
}