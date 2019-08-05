using ForumEpam2019.Entities.Context;
using ForumEpam2019_Entities.Identity.Interfaces;
using ForumEpam2019_Entities.Models;

namespace ForumEpam2019_Entities.Identity.Repositories
{
    public class ClientService : IClientService
    {
        public ForumContext Database { get; set; }
        public ClientService(ForumContext db)
        {
            Database = db;
        }

        public void Create(Account item)
        {
           // Database.Accounts.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
