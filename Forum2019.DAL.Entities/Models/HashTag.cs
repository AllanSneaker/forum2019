using System.Collections.Generic;

namespace ForumEpam2019_Entities.Models
{
    public class HashTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public HashTag()
        {
            Posts = new List<Post>();
        }
    }
}