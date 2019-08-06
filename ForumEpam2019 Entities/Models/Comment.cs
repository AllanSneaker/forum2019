using System;

namespace ForumEpam2019_Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual Author Author { get; set; }
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}