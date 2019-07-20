using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumEpam2019.Entities.Context;
using ForumEpam2019.Entities.Interfaces;
using ForumEpam2019.Entities.Models;
using ForumEpam2019_Entities.Interfaces;
using ForumEpam2019_Entities.Models;

namespace ForumEpam2019_Entities.Repositories
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private ForumContext db;
        private GenericRepository<ProfileInfo> profileInfoRepository;
        private GenericRepository<Comment> commentRepository;
        private GenericRepository<Post> postRepository;

        public UnitOfWorkEF(ForumContext context)
        {
            db = context;
        }
        public IRepository<ProfileInfo> ProfileInfos => 
            profileInfoRepository ?? (profileInfoRepository = new GenericRepository<ProfileInfo>(db));

        public IRepository<Comment> Comments => 
            commentRepository ?? (commentRepository = new GenericRepository<Comment>(db));


        public IRepository<Post> Posts =>
            postRepository ?? (postRepository = new GenericRepository<Post>(db));

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

