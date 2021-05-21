using System;
using System.Linq;
using MongoDB.Driver;
using RegisterUsers.Core.Domain.Intefaces;
using RegisterUsers.Core.Repository.Context;
using RegisterUsers.Core.Repository.Interfaces;


namespace RegisterUsers.Core.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collectionName;
        
        public Repository(IMongoCollection<T> collectionName)
        {
            _collectionName = collectionName;
        }
        
        protected Repository(IConnectionFactory connectionFactory, string databaseName, string collectionName)
        {
            _collectionName = connectionFactory.GetDatabase(databaseName).GetCollection<T>(collectionName);
        }
        
        public IQueryable<T> QueryAll()
        {
            return _collectionName.AsQueryable<T>();
        }

        public void Insert(T obj)
        {
            _collectionName.InsertOne(obj);
        }
    }
}