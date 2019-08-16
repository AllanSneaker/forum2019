using System;
using System.Collections.Generic;
using ForumEpam2019_Entities.Models;

namespace ForumEpam2019_Entities.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account Get(string id);
        void Create(Account item);
        void Update(Account item);
        void Delete(string id);
        IEnumerable<Account> Find(Func<Account, bool> predicate);
    }
}