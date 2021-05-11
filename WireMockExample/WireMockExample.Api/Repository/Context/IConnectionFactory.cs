using MongoDB.Driver;

namespace WireMockExample.Api.Repository.Context
{
    public interface IConnectionFactory
    {
        IMongoClient GetClient();

        IMongoDatabase GetDatabase(IMongoClient mongoClient, string databaseName);

        IMongoDatabase GetDatabase(string databaseName);
    }
}