using ForumEpam2019.Entities.Context;
using ForumEpam2019_Entities.Identity.Interfaces;
using ForumEpam2019_Entities.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace ForumEpam2019_Entities.Identity.Repositories
{
    public class UnitOfWorkIdentity : IUnitOfWorkIdentity
    {
        private readonly ForumContext _db;

        private readonly ApplicationUserService _userService;
        private readonly ApplicationRoleService _roleService;
        private readonly IClientService _clientService;

        public UnitOfWorkIdentity(/*string connectionString*/)
        {
            _db = new ForumContext(/*connectionString*/);
            _userService = new ApplicationUserService(new UserStore<ApplicationUser>(_db));
            _roleService = new ApplicationRoleService(new RoleStore<ApplicationRole>(_db));
            _clientService = new ClientService(_db);
        }

        public ApplicationUserService UserService => _userService;

        public IClientService ClientService => _clientService;
        public ApplicationRoleService RoleService => _roleService;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userService.Dispose();
                    _roleService.Dispose();
                    _clientService.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
