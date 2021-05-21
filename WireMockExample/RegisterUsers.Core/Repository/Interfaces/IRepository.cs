using System;
using System.Linq;

namespace RegisterUsers.Core.Repository.Intefaces
{
    public interface IRepository<T>
    {
        IQueryable<T> QueryAll();

        void Insert(T obj);
    }
}