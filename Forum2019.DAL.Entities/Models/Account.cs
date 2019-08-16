using ForumEpam2019_Entities.Identity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumEpam2019_Entities.Models
{
    public class Account
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoggedOn { get; set; }
        public string[] Roles { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
