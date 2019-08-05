using System.Collections.Generic;

namespace ForumEpam2019_Entities.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
