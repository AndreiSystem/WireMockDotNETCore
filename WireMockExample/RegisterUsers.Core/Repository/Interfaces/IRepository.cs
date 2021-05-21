using System.Linq;

namespace RegisterUsers.Core.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> QueryAll();

        void Insert(T obj);
    }
}