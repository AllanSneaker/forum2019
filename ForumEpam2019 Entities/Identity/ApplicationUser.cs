using System.Collections.Generic;
using ForumEpam2019_Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumEpam2019_Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
