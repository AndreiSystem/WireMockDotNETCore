using MongoDB.Driver;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.Repository.Base;
using RegisterUsers.Core.Repository.Context;

namespace RegisterUsers.Core.Repository
{
    public sealed class UserRepository : Repository<User>
    {
        public UserRepository(IMongoCollection<User> collectionName) : base(collectionName)
        {
        }

        public UserRepository(IConnectionFactory connectionFactory, string databaseName, string collectionName)
            : base(connectionFactory, databaseName, collectionName)
        {
        }
    }
}