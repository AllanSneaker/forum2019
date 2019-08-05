using System.Collections.Generic;

namespace ForumEpam2019.BusinessLayer.DTO
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<CommentDto> Comments { get; set; }

        public AuthorDto()
        {
            Posts = new List<PostDto>();
            Comments = new List<CommentDto>();
        }
    }
}
