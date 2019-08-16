using ForumEpam2019_Entities.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumEpam2019_Entities.Identity.Repositories
{
    public class ApplicationRoleService : RoleManager<ApplicationRole>
    {
        public ApplicationRoleService(RoleStore<ApplicationRole> store)
            : base(store)
        { }
    }
}
