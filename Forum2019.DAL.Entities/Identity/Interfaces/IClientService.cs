using ForumEpam2019_Entities.Models;
using System;

namespace ForumEpam2019_Entities.Identity.Interfaces
{
    public interface IClientService : IDisposable
    {
        void Create(Account item);
    }
}
