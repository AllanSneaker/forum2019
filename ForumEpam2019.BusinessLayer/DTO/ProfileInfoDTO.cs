using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumEpam2019.BusinessLayer.DTO
{
    public class ProfileInfoDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
    }
}
