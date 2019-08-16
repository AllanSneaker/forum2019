using System;
using System.Collections.Generic;

namespace ForumEpam2019_Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<HashTag> HashTags { get; set; }
        public DateTime Date { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
            HashTags = new List<HashTag>();
        }

    }
}
