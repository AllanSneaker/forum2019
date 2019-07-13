using System;

namespace ForumEpam2019.BusinessLayer.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}