using System.Collections.Generic;

namespace ForumEpam2019.BusinessLayer.Repository
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool IfExist(int id);
        bool Add(T value);
        bool Edit(int Id, T value);
        void Dispose();
    }
}