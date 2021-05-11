using System;
using System.Linq;
using WireMockExample.Api.Domains.Entities;

namespace WireMockExample.Api.Services.Interfaces
{
    public interface IUserServices
    {
        IQueryable<User> QueryAll();

        User Query(Guid id);

        void Insert(User user);
    }
}