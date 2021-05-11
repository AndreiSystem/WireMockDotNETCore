using System;
using System.Linq;
using MongoDB.Driver;
using WireMockExample.Api.Domains.Interfaces;
using WireMockExample.Api.Repository.Context;
using WireMockExample.Api.Repository.Interfaces;

namespace WireMockExample.Api.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collectionName;

        protected Repository(IMongoCollection<T> collectionName)
        {
            _collectionName = collectionName;
        }

        protected Repository(IConnectionFactory connectionFactory, string databaseName, string collectionName)
        {
            _collectionName = connectionFactory.GetDatabase(databaseName).GetCollection<T>(collectionName);

        }
        
        public IQueryable<T> QueryAll()
        {
            return _collectionName.AsQueryable();
        }

        public T Query(Guid id)
        {
            return _collectionName.AsQueryable().FirstOrDefault(w => w.Id == id);
        }

        public void Insert(T obj)
        {
            _collectionName.InsertOne(obj);
        }
    }
}