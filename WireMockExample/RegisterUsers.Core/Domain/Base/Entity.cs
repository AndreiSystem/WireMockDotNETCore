using System;
using MongoDB.Bson.Serialization.Attributes;
using RegisterUsers.Core.Domain.Intefaces;

namespace RegisterUsers.Core.Domain.Base
{
    [BsonIgnoreExtraElements]
    public abstract class Entity : IEntity
    {
        public string ContextId { get; set; }

        protected Entity()
        {
            ContextId = Guid.NewGuid().ToString();
        }
    }
}