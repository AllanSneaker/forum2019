using System;
using System.Collections.Generic;

namespace ForumEpam2019.BusinessLayer.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        //public AuthorDto Author { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<string> HashTags { get; set; }
        public DateTime Date { get; set; }

        //public PostDto()
        //{
        //    Comments = new List<CommentDto>();
        //    HashTags = new List<HashTagDto>();
        //}
    }
}
