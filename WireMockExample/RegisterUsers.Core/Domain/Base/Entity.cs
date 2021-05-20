using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RegisterUsers.Core.Domain.Intefaces;

namespace RegisterUsers.Core.Domain.Base
{
    [BsonIgnoreExtraElements]
    public abstract class Entity : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ContextId { get; set; }

        protected Entity()
        {
            this.ContextId = Guid.NewGuid().ToString();
        }
    }
}