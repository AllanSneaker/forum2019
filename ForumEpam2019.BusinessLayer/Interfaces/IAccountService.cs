using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ForumEpam2019.BusinessLayer.DTO;

namespace ForumEpam2019.BusinessLayer.Interfaces
{
    public interface IAccountService : IDisposable
    {
        Task<OperationDetails> CreateAccount(AccountDto accountDto);
        IEnumerable<AccountDto> GetAccounts();
        Task<Tuple<ClaimsIdentity, ClaimsIdentity>> FindAsyncAccount(string userName, string password);
        IEnumerable<string> GetRoles();
        void Dispose();
    }
}