using System;
using System.Linq;
using RegisterUsers.Core.Domain.Entities;

namespace RegisterUsers.Core.Services.Interfaces
{
    public interface IUserServices
    {
        IQueryable<User> QueryAll();
        User Query(string id);
        User InsertOrUpdate(User user);
    }
}