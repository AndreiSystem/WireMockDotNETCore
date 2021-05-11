using MongoDB.Driver;
using WireMockExample.Api.Domains.Entities;
using WireMockExample.Api.Repository.Base;
using WireMockExample.Api.Repository.Context;

namespace WireMockExample.Api.Repository
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