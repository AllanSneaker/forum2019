using System;
using ForumEpam2019.Entities.Models;
using ForumEpam2019_Entities.Interfaces;
using ForumEpam2019_Entities.Models;

namespace ForumEpam2019.Entities.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ProfileInfo> ProfileInfos{ get; }
        IRepository<Comment> Comments { get; }
        IRepository<Post> Posts { get; }
        IRepository<Author> Authors { get; }
        IRepository<HashTag> HashTags { get; }
        void Save();
    }
}