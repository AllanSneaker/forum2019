using System.Collections.Generic;

namespace ForumEpam2019.BusinessLayer.DTO
{
    public class AccountDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoggedOn { get; set; }
        public string[] Roles { get; set; }
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public AccountDto()
        {
            Posts = new List<PostDto>();
            Comments = new List<CommentDto>();
        }
    }
}
