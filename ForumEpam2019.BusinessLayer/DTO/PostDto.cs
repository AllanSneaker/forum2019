using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumEpam2019.BusinessLayer.DTO
{
   public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual AuthorDto Author { get; set; }
        public virtual List<CommentDto> Comments { get; set; }
        /// <summary>
        /// something like likes  
        /// </summary>
        public int Rate { get; set; }

        public HashTagDto HashTag { get; set; }
        public DateTime Date { get; set; }
    }
}
