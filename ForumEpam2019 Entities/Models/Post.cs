using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumEpam2019_Entities.Models
{
   public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<Comment> Comments { get; set; }
        /// <summary>
        /// something like likes  
        /// </summary>
        public int Rate { get; set; }

        public HashTag HashTag { get; set; }
        public DateTime Date { get; set; }

    }
}
