using System;
using System.Threading.Tasks;
using ForumEpam2019_Entities.Identity.Repositories;

namespace ForumEpam2019_Entities.Identity.Interfaces
{
    public interface IUnitOfWorkIdentity : IDisposable
    {
        ApplicationUserService UserService { get; }
        IClientService ClientService { get; }
        ApplicationRoleService RoleService { get; }
        Task SaveAsync();
    }
}