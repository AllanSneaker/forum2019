using ForumEpam2019.Entities.Context;
using ForumEpam2019.Entities.Interfaces;
using ForumEpam2019.Entities.Models;
using ForumEpam2019_Entities.Interfaces;
using ForumEpam2019_Entities.Models;
using System;

namespace ForumEpam2019_Entities.Repositories
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly ForumContext _db;
        private GenericRepository<ProfileInfo> _profileInfoRepository;
        private GenericRepository<Comment> _commentRepository;
        private GenericRepository<Post> _postRepository;
        private GenericRepository<Author> _authorRepository;
        private GenericRepository<HashTag> _hashTagsRepository;

        public UnitOfWorkEF(ForumContext context)
        {
            _db = context;
        }
        public IRepository<ProfileInfo> ProfileInfos =>
            _profileInfoRepository ?? (_profileInfoRepository = new GenericRepository<ProfileInfo>(_db));

        public IRepository<Comment> Comments =>
            _commentRepository ?? (_commentRepository = new GenericRepository<Comment>(_db));


        public IRepository<Post> Posts =>
            _postRepository ?? (_postRepository = new GenericRepository<Post>(_db));

        public IRepository<Author> Authors =>
            _authorRepository ?? (_authorRepository = new GenericRepository<Author>(_db));

        public IRepository<HashTag> HashTags =>
            _hashTagsRepository ?? (_hashTagsRepository = new GenericRepository<HashTag>(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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

