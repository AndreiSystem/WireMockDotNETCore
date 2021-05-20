using System;
using System.Linq;

namespace RegisterUsers.Core.Repository.Intefaces
{
    public interface IRepository<T>
    {
        IQueryable<T> QueryAll();

        T Query(string id);
        void Insert(T obj);
    }
}