using ForumEpam2019.Entities.Context;
using ForumEpam2019_Entities.Interfaces;
using ForumEpam2019_Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ForumEpam2019_Entities.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public ForumContext Database { get; set; }

        public AccountRepository(ForumContext db)
        {
            Database = db;
        }

        public IEnumerable<Account> GetAll()
        {
            return Database.Accounts;
        }

        public Account Get(string id)
        {
            return Database.Accounts.Find(id);
        }

        public void Create(Account item)
        {
            Database.Accounts.Add(item);
        }

        public void Update(Account item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Account account = Database.Accounts.Find(id);
            if (account != null)
                Database.Accounts.Remove(account);
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate)
        {
            return Database.Accounts.Where(predicate).ToList();
        }
    }
}
