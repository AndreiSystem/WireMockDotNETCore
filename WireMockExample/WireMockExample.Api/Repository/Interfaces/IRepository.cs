using System;
using System.Linq;

namespace WireMockExample.Api.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> QueryAll();

        T Query(Guid id);

        void Insert(T obj);
    }
}