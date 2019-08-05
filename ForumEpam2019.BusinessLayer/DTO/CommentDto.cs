using System;

namespace ForumEpam2019.BusinessLayer.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}